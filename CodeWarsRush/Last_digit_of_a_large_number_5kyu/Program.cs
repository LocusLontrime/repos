using System.Numerics;
public class LastDigitOfLargeNumber // accepted on codewars.com
{
    public static int[][] powerCycles = new int[10][]
    {
        new int[]{ 0 },
        new int[]{ 1 },
        new int[]{ 2, 4, 8, 6 },
        new int[]{ 3, 9, 7, 1 },
        new int[]{ 4, 6 },
        new int[]{ 5 },
        new int[]{ 6 },
        new int[]{ 7, 9, 3, 1 },
        new int[]{ 8, 4, 2, 6 },
        new int[]{ 9, 1 },
    };

    public static HashSet<int> nonCycleNums = new HashSet<int>() { 0, 1, 5, 6 };

    static void Main(string[] args)
    {
        Console.WriteLine(LastDigit(BigInteger.Parse("36715290469715693021198967285016729344580685479654510946723"),
            BigInteger.Parse("688196152215529972736737174557165657483427362207517952651")));

        Console.WriteLine(LastDigit(3, 516666));
    }

    public static int LastDigit(BigInteger num, BigInteger power)
    {
        if (power == 0) 
        { 
            return 1;
        }

        int lastNumDigit = (int) (num % 10);                                           

        if (nonCycleNums.Contains(lastNumDigit)) 
        { 
            return lastNumDigit; 
        } 
 
        BigInteger res = (power - 1) % powerCycles[lastNumDigit].Length;

        return powerCycles[lastNumDigit][(int) res];
    }
}