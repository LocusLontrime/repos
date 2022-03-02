public class Sem1Task8 // Выяснить, кратно ли число заданному, если нет, вывести остаток.
{ 

    public static void Main(string[] args) 
    {
        Console.WriteLine("Enter a base number");
        int baseNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter some number");
        int number = int.Parse(Console.ReadLine());

        if (number % baseNumber == 0) Console.WriteLine("The number is divisible by baseNumber"); // divisible or not (renainder checking)
        else Console.WriteLine("The remainter is equal to " + number % baseNumber);        
    }
}