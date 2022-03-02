public class Sem2Task3 // Программа проверяет пятизначное число на палиндромом
{
    public static void Main(string[] args) // a long way for newbies
    {

        Console.WriteLine("Enter a 5-digit number: ");
        int n = int.Parse(Console.ReadLine());

        if (n >= 10000 && n < 100000)
        {
            int number = n;

            int digit5 = number % 10;
            number /= 10;
            int digit4 = number % 10;
            number /= 10;
            number /= 10;
            int digit2 = number % 10;
            number /= 10;
            int digit1 = number % 10;           

            if (digit5 == digit1 && digit4 == digit2) Console.WriteLine(n + " is Palindrom");
            else Console.WriteLine(n + " is not Palindrom");
        }
        else 
        {
            Console.WriteLine("Enter 5-digit number");
        }

        // Console.WriteLine(digit1 + " " + digit2 + " " + digit4 + " " + digit5);

    }
}