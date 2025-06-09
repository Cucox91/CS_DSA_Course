using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Arrays;

public class MyArray<T>
{
    public long Lenght { get; set; }
    public T[] Data { get; set; }

    public MyArray(T[] data, long lenght = 0)
    {
        Data = data;
        Lenght = lenght;
    }

    // This will be O(1)
    public T Get(long index)
    {
        return Data[index];
    }

    // This will be Time: O(n) and Space O(n)
    public long Push(T newValue)
    {
        T[] newArray = new T[Lenght + 1]; //O(n) Space Complexity.
        for (int i = 0; i < Lenght; i++)
        {
            newArray[i] = Data[i];
        }
        newArray[Lenght] = newValue;
        Data = newArray;
        Lenght++;
        return Lenght;
    }

    public void Pop()
    {
        T[] newArray = new T[Lenght - 1]; //O(n) Space Complexity.
        for (int i = 0; i < Lenght - 1; i++)
        {
            newArray[i] = Data[i];
        }

        Data = newArray;
        Lenght--;
    }

    public void PrintTraverse()
    {
        foreach (var item in Data)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public void Delete(long index)
    {
        // bool found = false;

        //Option 1.
        // for (long i = 0; i < Lenght - 1; i++)
        // {
        //     if (i != index)
        //     {
        //         if (found)
        //         {
        //             newArray[i] = Data[i];

        //         }
        //         else
        //         {
        //             newArray[i - 1] = Data[i];
        //         }
        //     }
        //     else
        //     {
        //         found = true;
        //     }
        // }

        T[] newArray = new T[Lenght - 1];

        //Option 2: Shifting
        for (long i = index; i < Lenght - 1; i++)
        {
            Data[i] = Data[i + 1];
        }

        for (int i = 0; i < Lenght - 1; i++)
        {
            newArray[i] = Data[i];
        }

        Data = newArray;
        Lenght--;

        // if (found)
        // {
        //     Data = newArray;
        //     Lenght--;
        // }
    }
}
