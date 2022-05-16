using System.Numerics; // accepted on codewars.com

public class PowerTowerModuloM 
{
    static void Main(string[] args)
    {
        Console.WriteLine(EulersTotientPhi(8769));

        Console.WriteLine(Tower(25588, 27805, 768));
    }

    public static int Tower(BigInteger b, BigInteger h, int m) // 366 36 98 989
    {
        // Return b ** b ** ... ** b, where the height is h, modulo m.

        // base cases

        if (m == 1) return 0; // k (mod 1)

        if (b == 1 || h == 0) return 1; // 1^k, k^0    

        if (b <= 4 && h <= 3) return (int) BigInteger.Remainder(NaivePowTow(b, h), m);

        int totient = EulersTotientPhi(m); // totient(modulo)

        // recurrent relation (from kyu's explanation of number theory
        BigInteger result = BigInteger.ModPow(b, Tower(b, h - 1, totient) + totient, m);

        return (int) result;
    }

    public static BigInteger NaivePowTow(BigInteger b, BigInteger h)
    { 
        BigInteger result = BigInteger.One;

        for (int i = 0; i < h; i++) result = BigInteger.Pow(b, (int) result);
        
        return result;
    }

    public static int EulersTotientPhi(int m) // algo for computing totient function
    {
        double totient = m;

        for (int i = 2; i * i <= m; i++) // searching for factors of m
        {
            if (m % i == 0)
            {
                while (m % i == 0) m = m / i; // if a current factor repeats

                totient = totient * (1.0 - 1.0 / i); // Euler's product formula
            }
        }

        if (m > 1) totient = totient * (1.0 - 1.0 / m); // there is a factor that is larger than sqrt(m), only one such factor is possible

        return (int)totient;
    }
}