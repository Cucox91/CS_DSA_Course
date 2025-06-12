using System.ComponentModel;

namespace StackAndQueues;

public class MyStack<T>
{
    private readonly object?[] _data;
    private long _top;

    public MyStack(long Size)
    {
        _data = new object?[Size];
        _top = 0;
    }

    public T? Peek()
    {
        if (_top == 0)
        {
            return default;
        }

        var value = (T?)_data[_top - 1];
        if (value != null)
        {
            return value;
        }

        return default;
    }

    public void Push(T value)
    {
        if (_data.Length - 1 == _top)
        {
            Console.WriteLine("Stack is Full! Element not Inserted!");
        }

        _data[_top] = value;
        _top++;
    }

    public T? Pop()
    {
        if (_top == 0)
        { return default; }

        var value = (T?)_data[_top - 1];
        _data[_top] = null;
        if (_top > 0)
        {
            _top--;
        }

        if (value != null)
        {
            return value;
        }

        return default;
    }
}
