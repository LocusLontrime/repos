using System.Numerics;

public class Fibonacci 
{
    public static BigInteger[] memoTable;

    static void Main(string[] args) // 0 1 1 2 3 5 8
    {
        int N = 1000000;

        memoTable = new BigInteger[N + 1];

        Array.Fill(memoTable, 0);

        // Console.WriteLine($"{N}-th Fib number = {FibRec(N)}");

        // Console.WriteLine($"{N}-th Fib number = {FibRecMemo(N)}");

        Console.WriteLine($"{N}-th Fib number = {Fib(N)}");
    }

    public static BigInteger Fib(int N) 
    {
        BigInteger fibOneBefore = 1;
        BigInteger fibTwoBefore = 0;

        for (int i = 0; i < N; i++) 
        {
            fibOneBefore = fibOneBefore + fibTwoBefore;
            fibTwoBefore = fibOneBefore - fibTwoBefore;
        }

        return fibOneBefore;
    }

    public static int FibRec(int N) // the least optimized met
    {
        if (N == 1) return 1;
        else if (N == 0) return 0;
        else return FibRec(N - 1) + FibRec(N - 2);
    }

    public static BigInteger FibRecMemo(int N) // an optimized met
    {
        if (N == 1) return 1;
        if (N == 0) return 0;

        if (memoTable[N] == 0) memoTable[N] = FibRecMemo(N - 1) + FibRecMemo(N - 2);

        return memoTable[N];    
    }
}