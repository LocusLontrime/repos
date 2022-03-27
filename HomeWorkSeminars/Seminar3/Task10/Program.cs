public class Task10 
{
    static void Main(string[] args) // Напишите программу, которая принимает на вход трёхзначное число
                                    // и на выходе выводит перевёрнутое число
    {
        Console.WriteLine("Enter a 3-digit number: ");
        int num = int.Parse(Console.ReadLine());

        if (num >= 100 && num <= 999)
        {
            // num = 789
            int d3, d2, d1;

            d3 = num % 10; // d3 = 9
            num = num / 10; // num = 78

            d2 = num % 10; // d2 = 8

            d1 = num / 10; // d1 = 7;

            Console.WriteLine(d3 * 100 + d2 * 10 + d1);
        }
        else 
        {
            Console.WriteLine("Your number is invalid, PLEASE! Enter a 3-digit number: ");
        }      
    }
}