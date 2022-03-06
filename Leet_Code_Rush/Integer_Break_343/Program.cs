
using System.Numerics;
using System.Diagnostics;

public class IntegerBreak343 { // accepted (speed: 20ms, ultra-fast, beats 98,83% C# submissions) 

    public static BigInteger[] memoTable;
    public static int recursiveCounter = 0;

    public static void Main(string[] args)
    {
        var watch = Stopwatch.StartNew();
        Console.WriteLine(IntegerBreak(1366));

        watch.Stop();
        
        // foreach(BigInteger i in memoTable) Console.WriteLine(i);
        Console.WriteLine("recursiveCounter = " + recursiveCounter);
        Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + " ms");
    }

    public static BigInteger IntegerBreak(int n)
    {
        if (n == 2) return 1;
        if (n == 3) return 2;

        memoTable = new BigInteger[n + 1];

        // return recursiveSeeker(n);
        return recursiveSeekerFast(n);
    }

    public static BigInteger recursiveSeeker(int N) // brute-force rec with memo
    {
        recursiveCounter++;

        if (N == 0) return 1;

        if (memoTable[N] == 0)       
        {
            BigInteger currentMax = 0;

            for (int i = 1; i <= N; i++) currentMax = BigInteger.Max(currentMax, i * recursiveSeeker(N - i));

            memoTable[N] = currentMax;
        }

        return memoTable[N];
    }

    public static BigInteger recursiveSeekerFast(int N) // a fast one -> O(n), can be easily rewritten to a bottom-up version
    {
        recursiveCounter++;

        if (N == 0) return 1;

        BigInteger currentMax = 0;

        if (N >= 5) currentMax = BigInteger.Max(currentMax, 3 * recursiveSeekerFast(N - 3));
        else for (int i = 1; i <= N; i++) currentMax = BigInteger.Max(currentMax, i * recursiveSeekerFast(N - i));

        return currentMax;
    }

}