public class MySSQueue
{

    Stack<int> _s1 = new Stack<int>();
    Stack<int> _s2 = new Stack<int>();
    bool firstStack = true; // True = S1, False = S2.

    public MySSQueue()
    {

    }

    public void Push(int x)
    {
        var length = _s1.Count;
        for (int i = 0; i < length; i++)
        {
            _s2.Push(_s1.Pop());
        }

        _s2.Push(x);
    }

    public int Pop()
    {
        var length = _s2.Count;
        for (int i = 0; i < length; i++)
        {
            _s1.Push(_s2.Pop());
        }

        return _s1.Pop();
    }

    public int Peek()
    {
        return _s1.Peek();
    }

    public bool Empty()
    {
        return _s1.Count + _s2.Count == 0;
    }
}
