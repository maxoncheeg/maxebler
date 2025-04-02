using maxembler.Models.StateMachines.Abstract;
using System;
using maxembler.Models.StateMachines.EventArgs;
using ErrorEventArgs = maxembler.Models.StateMachines.EventArgs.ErrorEventArgs;

namespace maxembler.Models.StateMachines;

public class FiniteStateMachine : IFiniteStateMachine
{
    private readonly string _startState;
    private readonly string _endState;
    
    private int _startIndex = 0;
    private int _length = 0;
    private string _currentState;
    private bool _inProgress;
    private bool _isFirstIteration = true;

    private readonly List<IRouteError> _errors = [];
    private readonly Dictionary<(string, string), IList<IRoute>?> _states;
    
    private List<IRoute> _currentRoutes = [];

    public IReadOnlyDictionary<(string, string), IList<IRoute>?> States => _states;
    
    public event EventHandler<StateEventArgs>? StateChanged;
    public event EventHandler<ErrorEventArgs>? ErrorOccurred;

    public FiniteStateMachine(List<IRoute> routes, string startState, string endState)
    {
        if (routes.Count == 0)
            throw new NullReferenceException("Finite states cannot be empty");

        _states = new Dictionary<(string, string), IList<IRoute>?>();
        _startState = startState;
        _endState = endState;

        // заполняем наш словарь состояний
        foreach (var route in routes)
        {
            if (!_states.TryAdd((route.StartState, route.EndState), [route]))
            {
                _states[(route.StartState, route.EndState)] ??= new List<IRoute>();
                _states[(route.StartState, route.EndState)]?.Add(route);
            }
        }

        _currentState = startState;
    }

    public bool PutChar(char symbol, int symbolIndex)
    {
        if (_isFirstIteration)
        {
            // вынести отдельно, кушает много памяти!
            _currentRoutes = _states.Where(state => state.Key.Item1 == _currentState)
                .SelectMany(state => state.Value ?? []).ToList();

            _isFirstIteration = false;
        }

        if (_inProgress == false)
        {
            _startIndex = symbolIndex;
            _length = 0;
        }

        List<IRouteError> newErrors = new List<IRouteError>();

        _length++;
        for (int i = 0; i < _currentRoutes.Count; i++)
        {
            _currentRoutes[i].PutChar(symbol);
            if (_currentRoutes[i].State == RouteState.Error)
            {
                newErrors.Add(new RouteError()
                {
                    StartIndex = _startIndex,
                    Position = symbolIndex,
                    EndState = _currentRoutes[i].EndState,
                    StartState = _currentRoutes[i].StartState,
                    Length = _length,
                    Error = _currentRoutes[i].ErrorMessage
                });

                _currentRoutes.RemoveAt(i--);
            }
            else if (_currentRoutes[i].State == RouteState.Completed)
            {
                _currentState = _currentRoutes[i].EndState;
                _isFirstIteration = true;
                
                StateChanged?.Invoke(this,
                    new StateEventArgs() { HasSearchCompleted = true, StartIndex = _startIndex, Length = _length });
                
                if (_currentState == _endState)
                {
                    Reset(symbolIndex);
                }

                break;
            }
        }

        if (_currentRoutes.Count == 0)
        {
            _errors.AddRange(newErrors);

            ErrorOccurred?.Invoke(this, new ErrorEventArgs() { Errors = _errors });
            _errors.Clear();

            var inProgress = _inProgress;
            Reset(symbolIndex);

            // повторное использование символа, на котором случилась ошибка
            if (inProgress)
                PutChar(symbol, symbolIndex);
        }

        _inProgress = true;

        return true;
    }

    private void Reset(int index)
    {
        foreach (var states in _states)
            if (states.Value != null)
                foreach (var route in states.Value)
                    route.Reset();

        _currentState = _startState;
        _inProgress = false;
        _startIndex = index;
        _isFirstIteration = true;
        _length = 0;
    }
}