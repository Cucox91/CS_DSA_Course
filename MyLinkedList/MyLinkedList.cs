namespace MyLinkedList;

public class MyLinkedList<T>
{
    public LinkedListNode<T> Head { get; set; }
    public LinkedListNode<T>? Tail { get; set; }
    public long Lenght { get; set; }

    public MyLinkedList(T value)
    {
        Head = new LinkedListNode<T>(value, null, null);
        Tail = Head;
        Lenght = 1;
    }

    public LinkedListNode<T>? Append(T value)
    {
        if (Tail == null) // Empty array case.
        {
            Tail = new LinkedListNode<T>(value);
            Head = Tail;
        }
        else if (Head == Tail) // Reference Equality. Only One element Currently.
        {
            Tail = new LinkedListNode<T>(value);
            Tail.Previous = Head;
            Head.Next = Tail;
        }
        else
        {
            var next = new LinkedListNode<T>(value);
            next.Previous = Tail;
            Tail.Next = next;
            Tail = next;
        }
        Lenght++;
        return Tail;
    }

    public LinkedListNode<T>? Prepend(T value)
    {
        if (Tail == null) // Empty array case.
        {
            Tail = new LinkedListNode<T>(value);
            Head = Tail;
        }
        if (Head == Tail) // Reference Equality. Only One element Currently.
        {
            Tail = new LinkedListNode<T>(value);
            Tail.Previous = Head;
            Head.Next = Tail;
        }
        else
        {
            var previous = new LinkedListNode<T>(value);
            previous.Next = Head;
            Head.Previous = previous;
            Head = previous;
        }
        Lenght++;
        return Head;
    }

    // For the case of index positively outside of the boundry I will append at the end. 
    public LinkedListNode<T>? Insert(T value, long index)
    {
        LinkedListNode<T> current = Head;
        if (Tail == null)
        {
            Tail = new LinkedListNode<T>(value);
            Head = Tail;
            current = Head;
        }
        else if (Tail == Head)
        {
            Tail = new LinkedListNode<T>(value);
            Tail.Previous = Head;
            Head.Next = Tail;
            current = Tail;
        }
        else if (index == 0)
        {
            return Prepend(value);
        }
        else
        {
            current = Head;
            while (index >= 0 && current.Next != null)
            {
                current = current.Next;
                index--;
            }

            var newNode = new LinkedListNode<T>(value);
            var oldNext = current.Next;

            current.Next = newNode;
            newNode.Previous = current;

            newNode.Next = oldNext;
            if (oldNext != null)
            {
                oldNext.Previous = newNode;
            }
            else
            {
                Tail = newNode;
            }
            current = newNode;
        }
        Lenght++;
        return current;
    }

    public bool Remove(long index)
    {
        if (index > Lenght || index < 0)
        {
            return false;
        }
        else
        {
            var current = Head;
            while (index > 0)
            {
                current = current!.Next;
                index--;
            }

            if (current!.Previous != null && current.Next != null)
            {
                current.Next.Previous = current.Previous;
                current.Previous.Next = current.Next;
            }
            else if (current.Next == null)
            {
                Tail = current.Previous;
                if (Tail != null)
                {
                    Tail.Next = null;
                }
            }
            else if (current.Previous == null)
            {
                Head = current.Next;
                if (Head != null)
                {
                    Head.Previous = null;
                }
            }
            else
            {
                Console.WriteLine("Emptying List");
            }
            Lenght--;
            return true;
        }
    }

    public void TraverseForwardFromHead()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void TraverseTraverseBackwardFromTail()
    {
        var current = Tail;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    // This is for an Excersice only and will break the back link of the list.
    public LinkedListNode<T> ReverseSingleLinkedList()
    {
        if (Head!.Next == null)
        {
            return Head;
        }
        var first = Head;
        Tail = Head;
        var second = first.Next;
        while (second != null)
        {
            var third = second.Next;
            second.Next = first;
            first = second;
            second = third;
        }
        Head.Next = null;
        Head = first;
        return Head;
    }
}

public class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode<T>? Next { get; set; }
    public LinkedListNode<T>? Previous { get; set; }

    public LinkedListNode(T value, LinkedListNode<T>? next = null, LinkedListNode<T>? previous = null)
    {
        Value = value;
        Next = next;
        Previous = previous;
    }
}
