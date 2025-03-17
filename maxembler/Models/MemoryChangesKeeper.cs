namespace maxembler.Models
{
    public class MemoryChangesKeeper : IChangesKeeper
    {
        private List<string> _changes = new();
        private int _index = 0;

        public bool HasChanges => _index <= _changes.Count - 1 || _changes.Count != 0;

        public void AddChanges(string text)
        {
            _changes.Insert(_index, text);
            if(_index != 0)
            {
                _changes.RemoveRange(0, _index);
                _index = 0;
            }
        }

        public void ClearChanges()
        {
            _index = 0;
            _changes.Clear();
        }

        public string GoBack()
        {
            if(_index + 1 >= _changes.Count)
                return _changes[_index];

            return _changes[++_index];
        }

        public string GoForward()
        {
            if(_index - 1 < 0)
                return _changes[_index];

            return _changes[--_index];
        }
    }
}
