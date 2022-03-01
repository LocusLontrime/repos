public class Sem2Task3version2 // Программа проверяет пятизначное число на палиндромом
{
    public static void Main(string[] args) // a fast way, works for every positive Integer
    {
        Console.WriteLine("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int oldNumber = n;
        int newNumber = 0;

        while (n > 0) {
            newNumber *= 10;
            newNumber += n % 10;
            n /= 10;
        }

        if (newNumber == oldNumber) Console.WriteLine(oldNumber + " is Palindrom");
        else Console.WriteLine(oldNumber + " is not Palindrom");        
    }    
}