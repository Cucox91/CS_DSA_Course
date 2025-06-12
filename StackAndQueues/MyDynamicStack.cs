namespace StackAndQueues;

public class StackNode<T>
{
    public StackNode(T? value, StackNode<T>? next = null, StackNode<T>? previous = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }

    public T? Value { get; set; }

    public StackNode<T>? Next { get; set; }

    public StackNode<T>? Previous { get; set; }
}

public class MyDynamicStack<T>
{
    private StackNode<T>? _head;
    private StackNode<T>? _tail;
    private long _size;

    public MyDynamicStack(T value)
    {
        _head = new StackNode<T>(value);
        _tail = _head;
        _size++;
    }

    public T? Peek()
    {
        if (_tail == null)
        {
            return default;
        }

        var value = _tail.Value;
        if (value != null)
        {
            return value;
        }

        return default;
    }

    public T? Pop()
    {
        if (_tail == null)
        {
            return default;
        }

        var value = _tail.Value;
        if (_tail.Previous != null)
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }
        else
        {
            _tail = null;
            _head = null;
        }

        _size--;
        if (value != null)
        {
            return value;
        }

        return default;
    }

    public void Push(T value)
    {
        if (_tail == null)
        {
            _head = new StackNode<T>(value);
            _tail = _head;
        }
        else
        {
            _tail.Next = new StackNode<T>(value, null, _tail);
            _tail = _tail.Next;
            _size++;
        }
    }

    public void Traverse()
    {
        var current = _head;
        if (current != null)
        {
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The Stack is Empty.");
        }
    }

}