using maxembler.Models.StateMachines.Abstract;

namespace maxembler.Models.StateMachines.EventArgs;

public class ErrorEventArgs : System.EventArgs
{
    public IList<IRouteError> Errors { get; init; } = [];
}