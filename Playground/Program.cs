
using BigO;
using SolveCodingProblems;
using Arrays;

// BigOClass.DoSomething();

// int[] array = new int[] { 1, 2, 4,4 };
// int[] array = new int[] { 6, 4, 3, 2, 1, 7 };
// int sum = 9;

// var result = SolveCodingProblems.SolveGoogleInterview.HasPairWithSum2(array, sum, true);
// var result = SolveCodingProblems.SolveGoogleInterview.HasPairWithSum1(array, sum);

// Console.WriteLine(result);


var myArray = new MyArray<int>(new int[] { 1, 2, 3, 4, 5, 6 }, 6);

Console.WriteLine(myArray.Get(4));

myArray.Push(7);
Console.WriteLine(myArray.Get(6));

myArray.Pop();
myArray.PrintTraverse();

myArray.Delete(0);
myArray.PrintTraverse();

myArray.Delete(myArray.Lenght - 1);
myArray.PrintTraverse();

myArray.Delete(2);
myArray.PrintTraverse();

