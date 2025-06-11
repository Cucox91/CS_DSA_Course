namespace HashTable;

public class SimpleNode<T>
{
    public string Key { get; set; }
    public T Value { get; set; }
}

public class MyHashTable<T>
{
    private LinkedList<SimpleNode<T>>[] _data;

    public MyHashTable(long size)
    {
        _data = new LinkedList<SimpleNode<T>>[size];
    }

    private long MyHashIndex(string key)
    {
        var hash = 0;
        for (int i = 0; i < key.Length; i++)
        {
            hash = (hash + Convert.ToInt32(key[i]) * i) % _data.Length;
        }
        return hash;
    }

    public void SetValue(string key, T value)
    {
        var address = MyHashIndex(key);
        if (_data[address] != null)
        {
            _data[address].AddLast(new SimpleNode<T> { Key = key, Value = value });
        }
        else
        {
            _data[address] = new LinkedList<SimpleNode<T>>();
            _data[address].AddLast(new SimpleNode<T> { Key = key, Value = value });
        }
    }

    public T? GetValue(string key)
    {
        var address = MyHashIndex(key);
        var list = _data[address];
        if (list != null)
        {
            var result = list.FirstOrDefault(t => t.Key == key);
            if (result != null)
            {
                return result.Value;
            }
        }
        return default;
    }

    public List<string> Keys() //The problem with this is that the searches will be > O(n).
    {
        List<string> keys = new List<string>();
        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i] != null)
            {
                var list = _data[i];
                foreach (var item in list)
                {
                    keys.Add(item.Key);
                }
            }
        }
        return keys;
    }
}
