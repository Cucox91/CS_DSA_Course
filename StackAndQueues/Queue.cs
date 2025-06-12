namespace StackAndQueues;

public class QueueNode<T>
{

    public QueueNode(T? value, QueueNode<T>? next = null, QueueNode<T>? previous = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }

    public T? Value { get; set; }

    public QueueNode<T>? Next { get; set; }

    public QueueNode<T>? Previous { get; set; }
}

public class MyQueue<T>
{
    private QueueNode<T>? _head;
    private QueueNode<T>? _tail;
    private long _size;

    public MyQueue(T value)
    {
        _head = new QueueNode<T>(value);
        _tail = _head;
        _size++;
    }

    public T? PeekLast()
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
    public T? PeekNext()
    {
        if (_head == null)
        {
            return default;
        }

        var value = _head.Value;
        if (value != null)
        {
            return value;
        }

        return default;
    }

    public T? Dequeue()
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

    public void Enqueue(T value)
    {
        if (_head == null)
        {
            _head = new QueueNode<T>(value);
            _tail = _head;
        }
        else
        {
            _head.Previous = new QueueNode<T>(value, _head, null);
            _head = _head.Previous;
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
            Console.WriteLine("The Queue is Empty.");
        }
    }

}