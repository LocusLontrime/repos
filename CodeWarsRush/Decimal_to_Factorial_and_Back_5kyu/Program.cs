public class DecimalToFactorialAndBack // accepted on codewars.com
{
    public static string dictionary = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    static void Main(string[] args)
    {

        Console.WriteLine(long.MaxValue);

        Console.WriteLine(factorial(20, 1));

        Console.WriteLine(string.Join(" ", MaxFactorialLEssThanOrEqualToN(long.MaxValue)));

        Console.WriteLine(Dec2FactString(463));

        Console.WriteLine(FactString2Dec("341010"));

    }

    public static string Dec2FactString(long nb)
    {
        return RecursiveSeeker(nb, "", 0);
    }

    public static string RecursiveSeeker(long nb, string res, long prevValue) 
    {
        if (nb == 0) 
        {        
            for (long i = prevValue; i > 1; i--) res += "0";       
            return res;
        }

        long[] pair = MaxFactorialLEssThanOrEqualToN(nb);

        long currentMaxFactorial = pair[0];
        long currValue = pair[1];

        int coefficient = (int) (nb / currentMaxFactorial);

        string sDelta = "";

        for (long i = prevValue; i > currValue + 1; i--) {
            sDelta += "0";
        }

        return RecursiveSeeker(nb - coefficient * currentMaxFactorial, res + sDelta + dictionary[coefficient], currValue);
    }

    public static long FactString2Dec(string str)
    {
        long result = 0;

        for (int i = 0; i < str.Length; i++) 
        {
            result += dictionary.IndexOf(str[str.Length - 1 - i]) * factorial(i, 1);
        }

        return result;
    }

    public static long[] MaxFactorialLEssThanOrEqualToN(long N) 
    {
        long currentFactorial = 1;

        int i;

        for (i = 1;; i++)
        {
            if (currentFactorial * i >= currentFactorial)
            {
                if (currentFactorial * i <= N) currentFactorial *= i;
                else break;
            }
            else break;
        }

        return new long[] { currentFactorial, i};
    }

    public static long factorial(int N, long res) => N == 0 ? res : factorial(N - 1, res * N);   
}