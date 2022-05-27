using System.Numerics;

public class NonBouncyNumbers 
{
    static void Main(string[] args)
    {
        Console.WriteLine(TotalIncDec(6));
    }

    public static BigInteger TotalIncDec(int x)
    {
        // Good Luck!

        // return Combs(x + 9, 9) + Combs(x + 10, 10) - 10 * x - 1;
        return CombsSum(x) - 10 * x - 1;
    }

    public static BigInteger Combs(int n, int k)
    {
        BigInteger numerator = 1, denominator = 1;

        for (int i = n; i > n - k; i--) 
        { 
            numerator *= i;
        }

        for (int i = 2; i <= k; i++) 
        { 
            denominator *= i;
        }

        return numerator / denominator;
    }

    public static BigInteger CombsSum(int n)  // sum of Combs(x + 9, 9) + Combs(x + 10, 10) at instance
    {
        BigInteger numerator = 1, denominator = 1;

        for (int i = n + 9; i > n; i--)
        {
            numerator *= i;
        }

        for (int i = 2; i <= 9; i++)
        {
            denominator *= i;
        }

        BigInteger res = numerator / denominator;

        return res + res * (n + 10) / 10;
    }
}