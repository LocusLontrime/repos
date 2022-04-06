using System.Text;

public class AddTask1 // На вход подаётся натуральное десятичное число.
                      // Проверьте, является ли оно палиндромом в двоичной записи
{
    static void Main(string[] args)
    {
        Console.WriteLine(GetBinRec(1023).ToString()); // Translating method test
        Console.WriteLine(IsPalindrome(1023));// IsPalindrom method test, 2 cases
        Console.WriteLine(IsPalindrome(1024));
    }

    public static bool IsPalindrome(int num) // checks if the num is Palindrome
    { 
        string s = GetBinRec(num).ToString(); // rec call
        for (int i = 0; 2 * i < s.Length; i++) if (s[i] != s[s.Length - 1 - i]) return false;      
        return true;
    }

    public static StringBuilder GetBinRec(int num) => num == 0 ? new StringBuilder("") : GetBinRec(num / 2).Append(num % 2); // subtle rec
                                                                                                                             // can't
                                                                                                                             // translate 0
}