using AuxLib;
using System.Diagnostics;

public class SortAnArray912 // MergeSort
{
    public static int n;
    static void Main(string[] args)
    {
        int[] arrayToBeSorted = new int[] { 3, 12, 77, 17, 18, 45, 98, 97, 11, 1, 1, 98};

        arrayToBeSorted = Lib.ArrayRandomFulfilling(10000000);

        Stopwatch watch = new Stopwatch();

        watch.Start();

        arrayToBeSorted = SortArray(arrayToBeSorted);

        watch.Stop();

        Console.WriteLine("Time elapsed in ms: " + watch.ElapsedMilliseconds);

        // Lib.PrintArray(arrayToBeSorted);
    }

    public static int[] SortArray(int[] nums)
    {
        n = nums.Length;
        return RecursiveMergeSort(nums, 0, n - 1);
    }

    public static int[] RecursiveMergeSort(int[] nums, int leftIndex, int rightIndex)
    {       
        if (leftIndex == rightIndex) return new int[] { nums[leftIndex] }; // base case of resursion, when the one element in array remained

        int pivotIndex = (leftIndex + rightIndex) / 2; // calculating a pivot element

        int[] leftArray = RecursiveMergeSort(nums, leftIndex, pivotIndex); // recurrent defining of a new left and right arrays
        int[] rightArray = RecursiveMergeSort(nums, pivotIndex + 1, rightIndex);

        return Merge(leftArray, rightArray); // merging the two parts in one array
    }

    public static int[] Merge(int[] leftArray, int[] rightArray) // merging algo
    {       
        int leftLength = leftArray.Length;
        int rightLength = rightArray.Length;

        int[] result = new int[leftLength + rightLength];

        int lP = 0, rP = 0; // two pointers

        while (lP < leftLength && rP < rightLength)
        {
            if (leftArray[lP] < rightArray[rP])
            {
                result[lP + rP] = leftArray[lP];
                lP++;
            }
            else 
            { 

                result[lP + rP] = rightArray[rP];
                rP++;
            }
        }

        for (int i = lP; i < leftLength; i++)
        {
            result[i + rP] = leftArray[i];
        }

        for (int i = rP; i < rightLength; i++)
        {
            result[i + lP] = rightArray[i];
        }

        return result;
    }  
}