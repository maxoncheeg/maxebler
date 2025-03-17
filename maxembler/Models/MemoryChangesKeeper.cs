namespace maxembler.Models
{
    public class MemoryChangesKeeper : IChangesKeeper
    {
        private readonly List<string> _changes = [];
        private int _index = 0;

        public bool HasChanges => _index <= _changes.Count - 1 || _changes.Count != 0;
        public event EventHandler<ChangesEventArgs>? ChangesOccurred;
        public bool CanForwardChanges => _index != 0;
        public bool CanBackChanges => _index != _changes.Count - 1;
        

        public void AddChanges(string text)
        {
            _changes.Insert(_index, text);
            
            if(_index != 0)
            {
                _changes.RemoveRange(0, _index);
                _index = 0;
            }
            
            ChangesOccurred?.Invoke(this, new ChangesEventArgs(CanBackChanges, CanForwardChanges));
        }

        public void ClearChanges()
        {
            _index = 0;
            _changes.Clear();
            ChangesOccurred?.Invoke(this, new ChangesEventArgs(CanBackChanges, CanForwardChanges));
        }

        public string GoBack()
        {
            if(_index + 1 >= _changes.Count)
                return _changes[_index];
            ++_index;
            
            ChangesOccurred?.Invoke(this, new ChangesEventArgs(CanBackChanges, CanForwardChanges));
            return _changes[_index];
        }

        public string GoForward()
        {
            if(_index - 1 < 0)
                return _changes[_index];
            --_index;
            
            ChangesOccurred?.Invoke(this, new ChangesEventArgs(CanBackChanges, CanForwardChanges));
            return _changes[_index];
        }
    }
}
