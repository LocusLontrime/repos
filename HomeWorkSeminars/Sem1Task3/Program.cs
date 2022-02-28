public class Sem1Task3 {

    static void Main(string[] args) // Выяснить является ли число чётным
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 0) Console.WriteLine("The number <" + number + "> is even"); // reminder checking
        else Console.WriteLine("The number <" + number + "> is odd");
    }
}
