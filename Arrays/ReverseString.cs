public static class ReverseString
{
    public static string Reverse1(string original)
    {
        string newString = "";

        for (int i = original.Length - 1; i >= 0; i++)
        {
            newString += original[i];
        }

        return newString;
    }

    public static string Reverse2(string original)
    {
        var newArray = original.Reverse().ToString();
        return newArray!;
    }

    // Best overall between speed and readability. But the really best is with XOR.
    public static string Reverse3(string original)
    {
        // Remember to add validations.

        char[] arr = original.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}