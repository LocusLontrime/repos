using System.Numerics;
public class LastDigitOfLargeNumber
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
        Console.WriteLine(LastDigit("3715290469715693021198967285016729344580685479654510946723",
            "68819615221552997273737174557165657483427362207517952651"));

        Console.WriteLine(LastDigit(3, 516666));
    }

    public static int LastDigit(string num, string power)
    {
        if (num.Length == 0 || power.Length == 0) throw new ArgumentException("Num or power lengths cannot be less than 1");

        BigInteger pow = BigInteger.Parse(power);
        if (pow == 0) return 1;

        int lastNumDigit = (int) char.GetNumericValue(num[num.Length - 1]);

        if (nonCycleNums.Contains(lastNumDigit)) return lastNumDigit;    
        
        // Console.WriteLine($"last digit of num: {lastNumDigit}");
       
        // Console.WriteLine($"power = {pow}");

        // Console.WriteLine($"powerCycles[lastNumDigit].Length: {powerCycles[lastNumDigit].Length}");

        BigInteger res = (pow - 1) % powerCycles[lastNumDigit].Length;

        // Console.WriteLine($"Big Integer res: {res}");

        return powerCycles[lastNumDigit][(int) res];
    }

    public static int LastDigit(int num, int power) 
    {
        if (power == 0) return 1;

        int lastNumDigit = num % 10;

        if (nonCycleNums.Contains(lastNumDigit)) return lastNumDigit;

        int res = (power - 1) % powerCycles[lastNumDigit].Length;

        return powerCycles[lastNumDigit][(int)res];
    }

    public static int LastDigit(int[] array) 
    {
        int curre

        for () 
        { 



        }


    }
}