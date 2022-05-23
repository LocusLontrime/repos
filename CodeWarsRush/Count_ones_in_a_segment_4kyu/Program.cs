using System.Numerics;

public class CountOnesInSegment // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(CountOnes(12, 29));
    }

    public static BigInteger CountOnes(long left, long right)
    {
        // Your code here       
        return CountOneForNum(right) - CountOneForNum(left - 1);
    }

    public static BigInteger CountOneForNum(long num) 
    {
        BigInteger res = BigInteger.Zero;

        while (num > 0) 
        {
            int binLength = (int) Math.Log2(num);

            Console.WriteLine(binLength + " " + num);

            res += binLength != 0 ? BigInteger.Pow(2, binLength - 1) * binLength + 1 : 1;

            num -= (long) BigInteger.Pow(2, binLength);

            res += num;
        }

        return res;
    }
}