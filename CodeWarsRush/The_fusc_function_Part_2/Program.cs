using System;
using System.Numerics;

public class TheFuscFunctionPart2 
{
    static void Main(string[] args)
    {
        Console.WriteLine(Fusc(BigInteger.Pow(2, 1000) + 9007199254740991L));

        Console.WriteLine(Fusc(0));

        Console.WriteLine(Fusc(1));
    }

    public static BigInteger Fusc(BigInteger n)
    {
        //your code here
        BigInteger p = BigInteger.Zero;
        BigInteger q = BigInteger.One;  

        while (n > 0) 
        {
            if (!n.IsEven) 
            {
                q = p + q;
                n = n / 2;
            }
            else 
            {
                p = p + q;
                n = (n - 1) / 2;
            }
        }

        return p;
    }

}