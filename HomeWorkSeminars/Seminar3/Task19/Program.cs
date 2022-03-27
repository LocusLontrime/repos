public class Task19 // Напишите программу, которая принимает на вход
                    // пятизначное число и проверяет, является ли оно палиндромом
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a 5-digit number: ");

        string s = Console.ReadLine(); // "12345"

        Console.WriteLine(s[0] == s[4] && s[1] == s[3]);
    }
}