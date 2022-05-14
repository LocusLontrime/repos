using System.Numerics;
using System.Text;

public class SomeEgyptianFractions // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(Decompose("11769791", "1178892117111117"));
    }

    public static string Decompose(string nrStr, string drStr)
    {
        // your code
        BigInteger p = BigInteger.Parse(nrStr);
        BigInteger q = BigInteger.Parse(drStr);

        if (p == 0) return "[]";

        if (p % q == 0) return $"[{p / q}]";

        BigInteger gcd = BigInteger.GreatestCommonDivisor(p, q);

        p /= gcd;
        q /= gcd;

        StringBuilder str = new StringBuilder("[");

        if (p > q) 
        {
            BigInteger intPart = GetIntPart(p, q);

            str.Append(intPart).Append(", ");

            p = p - intPart * q;
        }

        List<BigInteger> egyptians = new List<BigInteger>();   

        RecSeeker(p, q, egyptians);

        foreach (var egyptian in egyptians) 
        {
            str.Append("1/").Append(egyptian).Append(", ");
        }

        str.Remove(str.Length - 2, 2);
        str.Append("]");
        
        return str.ToString();
    }

    public static void RecSeeker(BigInteger p, BigInteger q, List<BigInteger> egyptians) 
    {
        // border cases
        if (p == 1) 
        { 
            egyptians.Add(q);
            return;
        }

        // body of rec
        BigInteger intPartMin = q / p + 1; // int division

        // Console.WriteLine($"intPartMin = {intPartMin}");

        egyptians.Add(intPartMin);

        BigInteger pNew = p * intPartMin - q;
        BigInteger qNew = q * intPartMin;

        BigInteger gcd = BigInteger.GreatestCommonDivisor(qNew, pNew);

        pNew /= gcd;
        qNew /= gcd;

        // recurrent relations
        RecSeeker(pNew, qNew, egyptians);
    }

    public static BigInteger GetIntPart(BigInteger p, BigInteger q) => p / q;  
}