namespace Sorting;

public static class SortAlgorithms
{
    /// <summary>
    /// Print a given array in one line.
    /// </summary>
    /// <param name="array">The Array to Print.</param>
    public static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Bubble Sort will have a Time Complexity of O(n^2) and Space Complexity of O(1).
    /// </summary>
    /// <param name="array">The unsorted Array.</param>
    /// <param name="descending">Sort Ascending or Descending.</param>    
    public static void BubbleSort(int[] array, bool descending = false)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (descending)
                {
                    if (array[i] < array[j])
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                else
                {
                    if (array[i] > array[j])
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Selection Sort will have a Time Complexity of O(n^2) and Space Complexity of O(1). 
    /// But is the worst performing Sorting Algorithm. 
    /// </summary>
    /// <param name="array">The unsorted Array.</param>
    /// <param name="descending">Sort Ascending or Descending.</param>   
    public static void SelectionSort(int[] array)
    {
        var length = array.Length;
        for (int i = 0; i < length; i++)
        {
            var min = i;
            var temp = array[i];
            for (int j = i + 1; j < length; j++)
            {
                if (array[j] < array[min])
                {
                    // Update to the new minimum.
                    min = j;
                }
            }
            array[i] = array[min];
            array[min] = temp;
        }
    }

    /// <summary>
    /// This Algorithm is better for when the list is almost sorted.
    /// </summary>
    /// <param name="array"></param>
    public static void InsertionSort(List<int> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] <= array[0])
            {
                var temp = array[i];
                array.RemoveAt(i);
                // Move to the First Position.
                array.Insert(0, temp);
            }
            else
            {
                for (int j = 1; j < i; j++)
                {
                    if (array[i] >= array[j - 1] && array[i] <= array[j])
                    {
                        var temp = array[i];
                        array.RemoveAt(i);
                        array.Insert(j, temp);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Merge sort is Time: O(n * log n) and Space O(n)
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<int> MergeSort(List<int> list)
    {
        if (list.Count == 1)
        {
            return list;
        }
        var divided = DivideList(list);
        var part1 = MergeSort(divided != null ? divided[0] : new List<int>());
        var part2 = MergeSort(divided != null ? divided[1] : new List<int>());

        // Optimize the Merge and Sort
        var merged = new List<int>();
        merged.AddRange(part1);
        merged.AddRange(part2);
        merged = merged.Order().ToList();

        return merged;
    }

    private static List<int>[]? DivideList(List<int> list)
    {
        if (list.Count > 0)
        {
            var half = (int)Math.Floor((double)list.Count / 2);
            var firstPart = list.GetRange(0, half);
            var secondPart = list.GetRange(half, list.Count - half);
            return new List<int>[] { firstPart, secondPart };
        }
        return null;
    }

    private static List<int>[]? DivideListPivot(List<int> list, int pivotIndex)
    {
        if (list.Count > 0)
        {
            var firstPart = list.GetRange(0, pivotIndex);
            var secondPart = list.GetRange(pivotIndex, list.Count - pivotIndex);
            return new List<int>[] { firstPart, secondPart };
        }
        return null;
    }

    private static List<int> QuickSort(List<int> list)
    {
        if (list.Count <= 1)
        {
            return list;
        }

        var random = new Random();
        var pivotIndex = random.Next(0, list.Count - 1);
        var



    }
}
