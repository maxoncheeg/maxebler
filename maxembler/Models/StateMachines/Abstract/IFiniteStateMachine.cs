using maxembler.Models.StateMachines.EventArgs;
using ErrorEventArgs = maxembler.Models.StateMachines.EventArgs.ErrorEventArgs;

namespace maxembler.Models.StateMachines.Abstract;

public interface IFiniteStateMachine
{
    public IReadOnlyDictionary<(string, string), IList<IRoute>?> States { get; }
    public event EventHandler<StateEventArgs> StateChanged;
    public event EventHandler<ErrorEventArgs> ErrorOccurred;
    
    public bool PutChar(char symbol, int index);
}