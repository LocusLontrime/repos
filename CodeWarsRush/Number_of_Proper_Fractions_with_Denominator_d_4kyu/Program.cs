using System.Diagnostics;

public class NumberOfProperFractionsWithDenominatorD // accepted on codewars.com
{

    static void Main(string[] args) 
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        Console.WriteLine(ProperFractions(999999999999999999));

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");
    }

    public static long ProperFractions(long n)
    {
        // good luck

        long result = n;
        
        for (long p = 2;
                 p * p <= n; ++p)
        {
            // Check if p is a prime factor.
            if (n % p == 0)
            {
                // If yes -->> update n and result
                while (n % p == 0) n /= p;

                result -= result / p;
            }
        }

        // there might be only one prime factor that is larger than sqrt(n)
        if (n > 1)
            result -= result / n;
        return result;
    }
}