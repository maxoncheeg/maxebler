namespace maxembler.Models;

public class ChangesEventArgs(bool canBackChanges, bool canForwardChanges) : EventArgs
{
    public bool CanForwardChanges => canForwardChanges;
    public bool CanBackChanges => canBackChanges;
}