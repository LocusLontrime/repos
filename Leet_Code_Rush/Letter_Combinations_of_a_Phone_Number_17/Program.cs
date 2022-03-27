using System.Text;

public class LetterCombinationsOfAPhoneNumber17 // accepted (speed: 132ms, fast enoughm beats 89.12% of C# submissions)
{
    static string[] nums = new string[8] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
    static string digits;
    static IList<string> result;

    public static void Main(string[] args)
    {
        foreach (string s in LetterCombinations("98")) Console.WriteLine(s); 
    }

    public static IList<string> LetterCombinations(string digits) // the main method
    {
        if (digits == null) return null;

        LetterCombinationsOfAPhoneNumber17.digits = digits;
        result = new List<string>();

        RecursiveSeeker(new StringBuilder(), 0); // recursive call

        return result;
    }

    public static void RecursiveSeeker(StringBuilder s, int i) // bactracking
    {
        if (i == digits.Length) // base case
        {
            result.Add(s.ToString());
            return; 
        }

        for (int j = 0; j < nums[int.Parse(digits[i] + "") - 2].Length; j++)
        {
            s.Append(nums[int.Parse(digits[i] + "") - 2][j]); // change

            // Console.WriteLine("parsed value = " + (int.Parse(digits[i] + "") - 2) + " symbol: " + nums[int.Parse(digits[i] + "") - 2][j]);

            // Console.WriteLine("\nstr1: " + s.ToString());

            RecursiveSeeker(s, i + 1); // next rec step
            s.Length--; // backtracking

            // Console.WriteLine("\nstr2 " + s.ToString());
        }
    }
}