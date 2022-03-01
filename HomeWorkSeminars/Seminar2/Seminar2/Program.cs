public class Sem2Task1 // Дано число. Проверить кратно ли оно 7 и 23
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        if (number % 7 == 0 && number % 23 == 0) Console.WriteLine(number + " is divisible by: " + 7 + " and " + 23);
        else Console.WriteLine(number + " is not divisible by: " + 7 + " and " + 23);
    }
}