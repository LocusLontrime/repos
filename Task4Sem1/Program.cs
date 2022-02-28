public class Sem1Task3
{

    static void Main(string[] args) // odd or even number
    {
        Console.WriteLine("Input some number");
        int num = int.Parse(Console.ReadLine());
        if (num % 2 == 0) Console.WriteLine("Number " + num + " is even");
        else Console.WriteLine("Number " + num + " is odd");
    }
}