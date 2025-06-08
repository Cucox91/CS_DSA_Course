using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace SolveCodingProblems;

public static class SolveGoogleInterview
{
    public static bool HasPairWithSum1(int[] array, int sum)
    {
        //They Mentioned that the array is sorted ascending.
        array = array.Order().ToArray<int>();

        int lowerIndex = 0;
        int upperIndex = array.Length - 1;

        /*I will iterate the following way: (Because the array is sorted ascending)
        I will add the two indexes values:
        If the value is lower than the sum then I increase the lowerIndex.
        If the value is above the sum then I decrease the upperIndex.
        If we find a sum then return true.
        If indexes are equal or cross then we return false.
        */

        while (lowerIndex < upperIndex)
        {
            var indexesSum = array[lowerIndex] + array[upperIndex];
            if (indexesSum == sum)
            {
                return true;
            }
            else if (indexesSum < sum)
            {
                lowerIndex++;
            }
            else if (indexesSum > sum)
            {
                upperIndex--;
            }
        }
        return false;
    }

    public static bool HasPairWithSum2(int[] array, int sum, bool displaySetData)
    {
        /*This solution is working with the compliment of the number and  storing it.*/

        HashSet<int> mySet = new HashSet<int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (mySet.Contains(array[i]))
            {
                if (displaySetData)
                {
                    Console.WriteLine("Printing Sets for True:");
                    PrintTheSet(mySet);
                }
                return true;
            }
            mySet.Add(sum - array[i]);
        }

        if (displaySetData)
        {
            Console.WriteLine("Printing Sets for False:");
            PrintTheSet(mySet);
        }
        return false;
    }

    private static void PrintTheSet(HashSet<int> set)
    {
        foreach (var item in set)
        {
            Console.WriteLine($"Key: {item}");
        }
    }
}
