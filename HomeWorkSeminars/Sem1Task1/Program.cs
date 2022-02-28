namespace Sem1Task1;

public class Sem1Task1 { // Вывести квадрат числа

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to be squared");
        int num1 = int.Parse(Console.ReadLine());
        num1 *= num1; // squaring

        Console.WriteLine("Given number squared: " + num1);
    }
}