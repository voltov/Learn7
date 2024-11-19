public class RecentlyUsedList
{
    private readonly LinkedList<string> _list;
    private readonly HashSet<string> _set;
    private readonly int _capacity;

    public RecentlyUsedList(int capacity = 5)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.", nameof(capacity));
        }

        _capacity = capacity;
        _list = new LinkedList<string>();
        _set = new HashSet<string>();
    }

    public void Add(string item)
    {
        if (string.IsNullOrEmpty(item))
        {
            throw new ArgumentException("Null or empty strings are not allowed.", nameof(item));
        }

        if (_set.Contains(item))
        {
            _list.Remove(item);
        }
        else if (_list.Count == _capacity)
        {
            var last = _list.Last.Value;
            _list.RemoveLast();
            _set.Remove(last);
        }

        _list.AddFirst(item);
        _set.Add(item);
    }

    public string Get(int index)
    {
        if (index < 0 || index >= _list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        var node = _list.First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }

        return node.Value;
    }

    public int Count => _list.Count;
}
