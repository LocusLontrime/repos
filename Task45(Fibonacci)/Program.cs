using System.Numerics;

public class Fibonacci { // 4 methods of calculating Fibonacci from the least optimized to the most one

    static long[] memo_table;

    public static BigInteger[,] fibonacci_matrix = new BigInteger[,] { { BigInteger.One, BigInteger.One }, { BigInteger.One, BigInteger.Zero } };

    public static BigInteger[,] E_matrix = new BigInteger[,] { { BigInteger.One, BigInteger.Zero }, { BigInteger.Zero, BigInteger.One } };

    public static void Main(string[] args)
    {
        //Console.WriteLine(fibonacci_recursive(43)); // very dangerous calculation, if n > 43 the runtime begins to terrify 
        //Console.WriteLine(fib_memo(10000));
        //Console.WriteLine(fib_bot_up(1000000)); 
        Console.WriteLine(fib_maxrix_fast(10000000));
    }

    public static long fibonacci_recursive(int n) // the least optimized method -> just for understanding how dangerous the recursion without memoization can be
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        return fibonacci_recursive(n - 1) + fibonacci_recursive(n - 2);
    }

    public static long fib_memo(int n) // method that combines recursion and memoization, requires O(n) extra space
    {
        memo_table = new long[n + 1];

        return fibonacci_rec_memo(n);
    }


    public static long fibonacci_rec_memo(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        if (memo_table[n] == 0) memo_table[n] = fibonacci_rec_memo(n - 1) + fibonacci_rec_memo(n - 2);

        return memo_table[n];
    }

    public static BigInteger fib_bot_up(int n) // a very fast method that uses bottom up approach, requires just O(1) extra space (sonstant)
    {
        BigInteger fib_1before = 1, fib_2before = 0;

        for (int i = 1; i < n; i++)
        {
            fib_1before = fib_1before + fib_2before;
            fib_2before = fib_1before - fib_2before;
        }
        return fib_1before;
    }

    public static BigInteger fib_maxrix_fast(long N) { // a fastest one, uses matrix representation of Fibonacci numbers and fast power rising

        return matrix_pow_recursive(fibonacci_matrix, N)[0, 1];

    }

    public static BigInteger[,] matrix_pow_recursive(BigInteger[,] matrix, long N) // fast power rising
    {
        if (N == 0) return E_matrix;
        if (N == 1) return matrix;

        if (N % 2 == 0) return matrix_pow_recursive(multiply_two_rows_matrices(matrix, matrix), N / 2);
        else return multiply_two_rows_matrices(matrix, matrix_pow_recursive(multiply_two_rows_matrices(matrix, matrix), (N - 1) / 2));
    }

    public static BigInteger[,] multiply_two_rows_matrices(BigInteger[,] a, BigInteger[,] b) // a method for multiplication of two matrix [2,2]
    {
        BigInteger[,] multiplication = new BigInteger[2,2];

        multiplication[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
        multiplication[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
        multiplication[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
        multiplication[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];

        return multiplication;
    }
}
