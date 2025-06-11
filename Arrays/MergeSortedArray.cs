
public static class MergeSortedArrays
{

    public static int[] Merge(int[] a, int[] b)
    {
        int[] newArray = new int[a.Length + b.Length];
        int idxNew = 0;
        int idxA = 0;
        int idxB = 0;

        while (idxA < a.Length && idxB < b.Length)
        {
            if (a[idxA] <= b[idxB])
            {
                newArray[idxNew] = a[idxA];
                idxA++;
                idxNew++;
            }
            else
            {
                newArray[idxNew] = b[idxB];
                idxB++;
                idxNew++;
            }
        }

        if (idxA == a.Length)
        {
            for (int i = idxB; i < b.Length; i++)
            {
                newArray[idxNew] = b[i];
                idxNew++;
            }
        }
        else if (idxB == b.Length)
        {
            for (int i = idxA; i < a.Length; i++)
            {
                newArray[idxNew] = a[i];
                idxNew++;
            }
        }

        return newArray;
    }
}