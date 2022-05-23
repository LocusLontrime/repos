public class ShortestStepsToNumber // accepted on codewars.com
{
    public static int[] memoTable;

    static void Main(string[] args)
    {
        int n = 9999;
        Console.WriteLine($"Shortest way to number {n} = {ShortestStepsToNum(n)}");

        Console.WriteLine($"Shortest way to number {n} = {RecSeekerFast(n)}");
    }

    public static int ShortestStepsToNum(int num)
    {     
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

    public static int RecSeekerFast(int num) => num == 1 ? 0 : num % 2 == 0 ? RecSeekerFast(num / 2) + 1 : RecSeekerFast(num - 1) + 1;   
}