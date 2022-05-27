using System.Numerics;

public class LastDigitOfHugeNumber 
{
    static void Main(string[] args)
    {
        Console.WriteLine(LastDigit(new int[] { 12, 30, 21 }));
        Console.WriteLine(LastDigit(new int[] { }));
        Console.WriteLine(LastDigit(new int[] { 0, 0 }));
        Console.WriteLine(LastDigit(new int[] { 0, 0, 0 }));
        Console.WriteLine(LastDigit(new int[] { 123232, 694022, 140249 }));
    }

    public static int LastDigit(int[] array)
    {
        // Write your code here
        BigInteger curr_value = 1;

        for (int i = array.Length - 1; i >= 0; i--) 
        {
            curr_value = BigInteger.Pow(array[i], (int) (curr_value < 4 ? curr_value : curr_value % 4 + 4));
            Console.WriteLine($"curr_val = {curr_value}");
        }

        return (int) (curr_value % 10);
    }
}