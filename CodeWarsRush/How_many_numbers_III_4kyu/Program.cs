using System.Diagnostics;

public class HowManyNumbersIII // accepted on codewars.com
{
    public static int counter;
    public static int recCount;
    public static List<long> res;

    static void Main(string[] args)
    {
        long num = 99999999999999999L;

        Stopwatch sw = new Stopwatch();

        sw.Start();

        Console.WriteLine("res: " + string.Join(" ",  FindAll(35, 6).ToArray()));

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");
    }

    public static List<long> FindAll(int sumDigits, int numDigits)
    {
        // Your code here!!
        counter = 0;
        recCount = 0;

        res = new List<long>();

        RecSeeker(0, 0, 0, sumDigits, numDigits, 1);

        // Console.WriteLine($"recCounter = {recCount}");

        Console.WriteLine($"Counter: " + counter);

        if (counter > 0) return new List<long>() { counter, res[0], res[res.Count - 1] };
        else return new List<long>() { };
    }

    public static void RecSeeker(long currNumber, int currDigs, int currSum, int sumDigits, int numDigits, int prevGigit)
    {
        recCount++;

        if (currDigs == numDigits) 
        {
            if (currSum == sumDigits)
            {
                counter++;

                // Console.WriteLine(currNumber);

                res.Add(currNumber);
            }

            return;
        }

        for (int i = prevGigit; currSum + i <= sumDigits && i < 10; i++) 
        {
            currNumber *= 10; // num building
            currNumber += i;

            RecSeeker(currNumber, currDigs + 1, currSum + i, sumDigits, numDigits, i);

            currNumber -= i; // backtracking
            currNumber /= 10;
        }
    }  
} 