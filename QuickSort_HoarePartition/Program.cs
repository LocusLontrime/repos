using AuxLib;
using System.Diagnostics;
public class QuickSort
{
    public static int recCount;

    public static int n;
    public static void Main(string[] args)
    {
        int[] array = new int[] { 1, 11, 16, 8, 6, 48, 54, 45, 44, 43, 1, 1, 1, 1, 98, 97, 989, 98, 97, 96, 99, 989 };

        array = Lib.ArrayRandomFulfilling(10000000);

        Stopwatch watch = new Stopwatch();

        watch.Start();

        QuickSortAlgo(array);

        watch.Stop();

        Console.WriteLine("Time elapsed in ms: " + watch.ElapsedMilliseconds);
        Console.WriteLine(recCount + " actions made");

        // Lib.PrintArray(array);
    }

    public static void QuickSortAlgo(int[] array) 
    { 
        n = array.Length;

        recCount = 0;

        RecursiveSort(array, 0, n - 1);
    }

    public static void RecursiveSort(int[] array, int leftBorder, int rightBorder) // Hoare Partition
    { 
        if (leftBorder == rightBorder) return;

        int pivotElement = (array[leftBorder] + array[rightBorder]) / 2; // At first we define the pivotElement (median)

        // Hoare's Partition
        int pivotIndex = ArrayPermutation(array, leftBorder, rightBorder, pivotElement); // here we're finding the pivotIndex

        RecursiveSort(array, leftBorder, pivotIndex); // recursive tree building, divide and conquer tactics
        RecursiveSort(array, pivotIndex + 1, rightBorder);
    }

    public static int ArrayPermutation(int[] array, int leftBorder, int rightBorder, int pivotElement) // Hoare's partition part
    {
        while (true)
        {
            while (array[leftBorder] < pivotElement) // skippint the elements that stayed at their place in the left side
            {
                recCount++;
                leftBorder++;
            }

            while (array[rightBorder] > pivotElement) // skippint the elements that stayed at their place in the right side
            {
                recCount++;
                rightBorder--;
            }

            if (leftBorder < rightBorder) // we are swapping two elements if they are both stay at wrong places
            {
                IntsPermutation(array, leftBorder++, rightBorder--);
            }
            else return rightBorder;        
        }
    }

    public static void IntsPermutation(int[] array, int i, int j) // swappint two array's elements
    {
        int temp;

        recCount++;

        temp = array[i]; 
        array[i] = array[j];
        array[j] = temp;
    }   
}
