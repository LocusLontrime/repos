using System.Numerics;

public class MaximizeNumberOfNiceDivisots1808 {

    public static void Main(string[] args)
    {
        Console.WriteLine(Maximize(5000000)); // 5000000 -> 559446548, 989 -> 678165681
    }

    public static int Maximize(int n) 
    {
        int maxNiceDivisors = 1;
        int power;

        int modulo = 1000000007;

        if (n >= 5) switch (n % 3)
                {
                    case 0: power = n / 3;
                        return (int) riseToPowerFast(3, power, modulo);
                    case 1: power = (n - 4) / 3;
                        return (int) (riseToPowerFast(3, power, modulo) * 4 % modulo);
                    default: power = (n - 2) / 3;
                        return (int) (riseToPowerFast(3, power, modulo) * 2 % modulo);
            }

        if (n == 1) return 1;
        if (n == 2) return 2;
        if (n == 3) return 2;
        if (n == 4) return 4;
        return 1;
    }

    public static BigInteger riseToPowerFast(BigInteger baseNumber, int power, int modulo) {
        if (power == 0) return 1;
        if (power == 1) return baseNumber;

        if (power % 2 == 0) return riseToPowerFast(baseNumber * baseNumber % modulo, power / 2, modulo);
        else return baseNumber * riseToPowerFast(baseNumber * baseNumber % modulo, (power - 1) / 2, modulo);
    }
}