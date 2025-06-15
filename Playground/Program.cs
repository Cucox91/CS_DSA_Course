using Sorting;


int[] array = new int[] { 1, 6, 768, 645, 345, 878, 98978, 543545, 432432, 22, 3, 5, 5 };
Console.WriteLine("Original List:");
SortAlgorithms.PrintArray(array);

Console.WriteLine("Bubble Sorted Descending:");
var newArray = array.ToArray();
SortAlgorithms.BubbleSort(newArray, true);
SortAlgorithms.PrintArray(newArray);

Console.WriteLine("Bubble Sorted Ascending:");
newArray = array.ToArray();
SortAlgorithms.BubbleSort(newArray, false);
SortAlgorithms.PrintArray(newArray);

Console.WriteLine("Selection Sort");
newArray = array.ToArray();
SortAlgorithms.SelectionSort(newArray);
SortAlgorithms.PrintArray(newArray);

Console.WriteLine("Insertion Sort");
var newList = array.ToList();
SortAlgorithms.InsertionSort(newList);
SortAlgorithms.PrintArray(newList.ToArray());

Console.WriteLine("Merge Sort");
newList = array.ToList();
var resulting = SortAlgorithms.MergeSort(newList);
SortAlgorithms.PrintArray(resulting.ToArray());

Console.WriteLine("Quick Sort");
newList = array.ToList();
resulting = SortAlgorithms.MergeSort(newList);
SortAlgorithms.PrintArray(resulting.ToArray());