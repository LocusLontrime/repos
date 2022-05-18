public class ShortestStepsToNumber
{
    public static int[] memoTable;

    static void Main(string[] args)
    {
        int n = 9999;

        Console.WriteLine($"Shortest way to number {n} = {ShortestStepsToNum(n)}");
    }

    public static int ShortestStepsToNum(int num)
    {
        // Good Luck!

        memoTable = new int[num + 1];

        return RecSeeker(num);
    }

    public static int RecSeeker(int num) 
    { 
        if (num == 1) return 0;
        else if (memoTable[num] != 0) return memoTable[num];

        if (num % 2 == 0) memoTable[num] = Math.Min(RecSeeker(num / 2), RecSeeker(num - 1)) + 1;
        else memoTable[num] = RecSeeker(num - 1) + 1;

        return memoTable[num];
    }
}