using System.Diagnostics;
using System.Text;

public class RomanNumerals // LL 36 366 98 989
{
    public static int[,] memoTable;
    public static string[] strsTable;
    
    public static int N;

    public static int recCounter;

    public static Dictionary<int, string> numerals = new Dictionary<int, string>() 
    {
        /* { 1, "I" },
        { 5, "V"},
        { 10, "X" },
        { 50, "L" },
        { 100, "C" },
        { 500, "D" },
        { 1000, "M" },
        { 5000, "V" },
        { 10000, "W"} */

        { 1000000, "M_"},
        { 500000, "D_"},
        { 100000, "C_"},
        { 50000, "L_"},
        { 10000, "X_"},
        { 5000, "V_" },      
        { 1000, "M" },
        { 500, "D" },
        { 100, "C" },
        { 50, "L" },
        { 10, "X" },
        { 5, "V"},
        { 1, "I" }
    };

    static void Main(string[] args)
    {




























        Stopwatch sw = new Stopwatch();

        sw.Start();

        string s = ToRoman(2453679, false);

        // Console.WriteLine($"Roman representation: {s}");

        Console.WriteLine($"recCounter = {recCounter}");

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");
    }

    public static string ToRoman(int n, bool flag) // false -->> two-ways Algo and true for one-way
    {
        memoTable = new int[2 * n + 1, 2]; // ???
        strsTable = new string[2 * n + 1];

        N = n;

        recCounter = 0;

        for (int i = 0; i < strsTable.Count(); i++) 
        {
            strsTable[i] = new string("");
        }
      
        int res = RecSeeker(n, n, flag); 

        Console.WriteLine($"res = {res}\n");

        int l = n;
        string s = "";

        while (l > 1) 
        {
            s = strsTable[l].ToString();

            int temp = memoTable[l, 1];

            Console.WriteLine($"s = {(temp < l ? "" : "-") + s}, l = {l}");

            l = temp;
        }

        // Console.WriteLine(strsTable[1990]);

        return "";
    }

    public static int RecSeeker(int n, int prevKey, bool flag)
    {    
        recCounter++;

        if (n == 0) return 0;

        if (memoTable[n, 0] == 0) { 

            int minPath = int.MaxValue;

            string symbol = "";           
            int k = 0;

            foreach (var kvp in numerals)
            {
                if (flag && kvp.Key > prevKey) continue; // important condition - changes the two-ways Algo to the one-way

                int nextMinusN = n - kvp.Key;
                int nextPlusN = n + kvp.Key;

                int nextN = 0;

                if (nextMinusN < 0) continue;              

                int nextStepsMinus = RecSeeker(nextMinusN, kvp.Key, flag);
                int nextStepsPlus = (n > N || kvp.Key >= prevKey) ? int.MaxValue : RecSeeker(nextPlusN, kvp.Key, flag);

                int pathRemained = 0;

                if (nextStepsPlus <= nextStepsMinus)
                {                   
                    pathRemained = nextStepsPlus;

                    nextN = nextPlusN;
                }
                else 
                {
                    pathRemained = nextStepsMinus;

                    nextN = nextMinusN;
                }

                if (pathRemained != int.MaxValue) pathRemained += 1;

                if (minPath > pathRemained)
                {
                    minPath = pathRemained;

                    symbol = $"{numerals[kvp.Key]}";

                    k = nextN;
                }
            }

            strsTable[n] = symbol; // .Append(" ").Append(k);

            // Console.WriteLine($"{n} {strsTable[n].ToString()}");

            memoTable[n, 0] = minPath;
            memoTable[n, 1] = k;
        }

        return memoTable[n, 0];
    }

    public static int FromRoman(string romanNumeral)
    {



        return 0;
    }
}