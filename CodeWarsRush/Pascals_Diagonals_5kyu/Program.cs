using System.Numerics;

public class PascalsDiagonals // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(String.Join(" ", GenerateDiagonal(5, 2)));
        Console.WriteLine(String.Join(" ", GenerateDiagonal(10, 1)));
        Console.WriteLine(String.Join(" ", GenerateDiagonal(50, 23)));
        Console.WriteLine(String.Join(" ", GenerateDiagonal(989, 989)));
    }

    public static BigInteger[] GenerateDiagonal(int n, int l)
    {
        // return an array containing the numbers in the nth diagonal of Pascal's triangle, to the specified length

        if (n == 0) return new BigInteger[] { };

        BigInteger[] result = new BigInteger[n];

        BigInteger currentCombinationsVal = 1;

        result[0] = BigInteger.One;

        for (int i = 1; i <= n - 1; i++)
        {
            currentCombinationsVal *= (l + i);
            currentCombinationsVal /= i;

            result[i] = currentCombinationsVal;
        }

        return result;
    }
}