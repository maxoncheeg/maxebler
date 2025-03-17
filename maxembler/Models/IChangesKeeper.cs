namespace maxembler.Models
{
    public interface IChangesKeeper
    {
        public bool HasChanges { get; }
        public void AddChanges(string text);
        public string GoBack();
        public string GoForward();
        public void ClearChanges();
    }
}
