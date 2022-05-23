using System.Diagnostics;
using System.Text;
public class LCS 
{
    public static string[,] memoTable;

    static void Main(string[] args) // 36 366 98 989
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        Console.WriteLine(Lcs("abcdefatt", "bdeffzat"));
        Console.WriteLine(Lcs("abcdefabcdefamyytttabcdefghhfdhdfgdsijklmnabcdasfdsgtrjyqqvmnefghijklmnopqabcdefghijklmnopqopqabcdefg" +
            "hijklmnopqabcdefghijklmnopqabcdefabcdefattabcdefghijklmnrtykvcbvabcdefghijklmnopqabcdefghijklmnopqopqabcdefghijklmnopqa", 
            "fedcbafedcbaapcdefghijklmnobqabcdefabcdeffedcbafqweqwfxxeffttuoportwe dcbaapcdefghijklmnobqabcdefabcdeffedcbafedcbaapcd" +
            "lmnobqabcdefabcdqwrwehbfddfdsgfdhgjyttkmnebevwecwcwvtruko9olooloyumyumtynrbervevwevrevrevrebvebtrehthyjuykiukillioloeff"));
        Console.WriteLine(Lcs("abcdef", "fedcba"));

        Console.WriteLine(Lcs("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));

        Console.WriteLine(Lcs("a", "abcdefattabcdefattabcdefattabcdefattabcdefattabcdefattabcdefattabcdefattabcdefattabcdefatt"));      

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");
    }

    public static string Lcs(string a, string b)
    {
        memoTable = new string[a.Length + 1, b.Length + 1];
        memoTableFill();
        Console.WriteLine(memoTable[0, 0].ToString());

        RecSeeker(a.Length, b.Length, a, b);

        return memoTable[a.Length, b.Length];
    }

    public static string RecSeeker(int i, int j, string a, string b) 
    {      
        if (memoTable[i, j].Length == 0)
        {
            if (i == 0 || j == 0)
            {
                return "";           
            }
            else if (a[i - 1] == b[j - 1])
            {              
                memoTable[i, j] = RecSeeker(i - 1, j - 1, a, b) + a[i - 1];
            }
            else
            {
                string s1 = RecSeeker(i, j - 1, a, b);
                string s2 = RecSeeker(i - 1, j, a, b);

                memoTable[i, j] = s1.Length > s2.Length ? s1 : s2;
            }           
        }  
        
        return memoTable[i, j];
    }

    public static void memoTableFill() 
    {
        for (int j = 0; j < memoTable.GetLength(0); j++)
        {
            for (int i = 0; i < memoTable.GetLength(1); i++)
            {
                memoTable[j, i] = "";
            }
        }
    }
}