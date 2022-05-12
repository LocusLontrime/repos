using System.Text;

public class GenerateParentheses22 
{
    public static IList<string> list;
    public static int N;
    public static void Main(string[] args)
    {
        IList<string> list = GenerateParenthesis(12);
        Console.WriteLine(list.Count);
        //foreach (string s in list) Console.WriteLine(s); ;
    }

    public static IList<string> GenerateParenthesis(int n)
    {
        list = new List<string>();
        N = n;

        RecursiveSeeker(new StringBuilder(), 0);

        return list;
    }

    public static void RecursiveSeeker(StringBuilder s, int n) 
    {
        if (n == 2 * N) 
        { 
            string str = s.ToString();

            if (IsParenthesisValid(str)) list.Add(str);

            return;
        }

        RecursiveSeeker(s.Append("("), n + 1);
        s.Remove(s.Length - 1, 1);
        RecursiveSeeker(s.Append(")"), n + 1);
        s.Remove(s.Length - 1, 1);
    }

    public static bool IsParenthesisValid(string s) 
    {
        int counter1 = 0;
        int counter2 = 0;

        foreach (char c in s) 
        { 
            if (c == '(') counter1++;
            else if (c == ')') counter2++;

            if (counter1 - counter2 < 0) return false;
        }

        if (counter1 - counter2 != 0) return false;

        return true;
    }
}