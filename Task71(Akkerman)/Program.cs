using System.Numerics;

public class Akkerman {

    static void Main(string[] args)
    {

        Console.WriteLine(AkkermanRecursion(3, 5));

        BigInteger bigInteger = new BigInteger(new byte[] {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});

        double d = Math.Pow(10, 20);

        Console.WriteLine((int) Math.Log2(d) + 1);

    }

    public static BigInteger AkkermanRecursion(BigInteger m, BigInteger n)
    {       
        if (m == 0) return n + 1;
        if (m > 0 && n == 0) return AkkermanRecursion(m - 1, 1);
        if (m > 0 && n > 0) return AkkermanRecursion(m - 1, AkkermanRecursion(m, n - 1));  
        
        return BigInteger.One;
    }

}
