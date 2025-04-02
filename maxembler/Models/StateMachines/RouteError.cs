using maxembler.Models.StateMachines.Abstract;

namespace maxembler.Models.StateMachines;

public class RouteError : IRouteError
{
    public required int Position { get; init; }
    public required int StartIndex { get; init; }
    public required int Length { get; init; }
    public required string StartState { get; init; }
    public required string EndState { get; init; }
    public string Error { get; init; } = string.Empty;
}