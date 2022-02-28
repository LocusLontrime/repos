public class Container_With_Most_Water {

    static int[,] memoTable;

    static void Main(string[] args) // accepted (speed: 176ms, very fast, beats 92,95% of c# submissions)
    {
        int[] array = new int[] {76, 155, 15, 188, 180, 154, 84, 34, 187, 142, 22, 5, 27, 183, 111, 128, 50, 58, 2, 112, 179, 2, 100, 111, 115, 76, 134, 120, 118, 103, 31, 146, 58, 198, 134, 38, 104, 170, 25, 92, 112, 199, 49, 140, 135, 160, 20, 185, 171, 23, 98, 150, 177, 198, 61, 92, 26, 147, 164, 144, 51, 196, 42, 109, 194, 177, 100, 99, 99, 125, 143, 12, 76, 192, 152, 11, 152, 124, 197, 123, 147, 95, 73, 124, 45, 86, 168, 24, 34, 133, 120, 85, 81, 163, 146, 75, 92, 198, 126, 191 }; // { 1, 1 }; // { 1, 8, 6, 2, 5, 4, 8, 3, 7 }; //;

        Console.WriteLine("Max container volume = " + findMaxCont(array));
        Console.WriteLine("Max container volume = " + findMaxContOptimized(array));
    }

    public static int findMaxCont(int[] array)  // out of memory< fast emough -> o(N) runtime and O(N^2) extraspace
    { 
        memoTable = new int[array.GetLength(0), array.GetLength(0)];

        return recuriveSeeker(0, array.GetLength(0) - 1, array);        
    }

    public static int recuriveSeeker(int i, int j, int[] array) { // recursive realization with memoization, very fast, but requires HUGE MEMORY!!! needs to be improved

        if (i == j) return 0;

        if (memoTable[i, j] != 0) return memoTable[i, j];
        else {
            memoTable[i, j] = Math.Max(Math.Min(array[i], array[j]) * (j - i), 
                Math.Max(recuriveSeeker(i + 1, j, array), recuriveSeeker(i, j - 1, array)));       
        }

        return memoTable[i, j];
    }

    public static int findMaxContOptimized(int[] array)
    {
        return recursiveSeekerOptimized(0, array.GetLength(0) - 1, array);  
    }

    public static int recursiveSeekerOptimized(int leftPointer, int rightPointer, int[] array) { 
       
        if (leftPointer == rightPointer) return 0;

        int currentArea = Math.Min(array[leftPointer], array[rightPointer]) * (rightPointer - leftPointer);

        if (array[leftPointer] < array[rightPointer]) return Math.Max(currentArea, recursiveSeekerOptimized(leftPointer + 1, rightPointer, array));
        else return Math.Max(currentArea, recursiveSeekerOptimized(leftPointer, rightPointer - 1, array));     
    }
}
