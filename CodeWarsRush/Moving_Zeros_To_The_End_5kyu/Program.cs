public class ZerosToTheEnd
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 0, 0, 0, 7, 4, 3, 6, 2, 0, 1, 2, 0, 1, 0, 1, 0, 3, 0, 1, 0, 0, 0 };

        Console.WriteLine(String.Join(" ", MoveZeroes(arr)));
    }

    public static int[] MoveZeroesInPlacePermut(int[] arr)
    {
        // TODO: Program me
        int lPointer = 0, rPointer = arr.Length - 1;
 
        while (lPointer < rPointer) 
        {
            while (arr[rPointer] == 0) rPointer--; // here we skip the tail zeroes
            while (arr[lPointer] != 0) lPointer++;

            Console.WriteLine($"lP = {lPointer}, rp = {rPointer}");

            if (lPointer <= rPointer && arr[lPointer] == 0 && arr[rPointer] != 0) Swap(lPointer++, rPointer--, arr);
        }

        Console.WriteLine(String.Join(" ", arr));

        return arr;
    }
    public static int[] MoveZeroes(int[] arr)
    { 
        int[] newArr = new int[arr.Length];

        int newArrPointer = 0;

        foreach (int i in arr)
        { 
            if (i != 0) newArr[newArrPointer++] = i;
        }

        return newArr;
    }

    public static void Swap(int j, int i, int[] arr) 
    {
        int temp = arr[j];
        arr[j] = arr[i];
        arr[i] = temp;
    }
} 