public class Sem1Task7 { // Удалить вторую цифру трёхзначного числа

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());
        if (number >= 100 && number < 1000) // whether the number is three-digit
        {
            int newNumber = (number / 100) * 10 + number % 10; // building of a new number
            Console.WriteLine("The number after operations: " + newNumber);
        }
        else
        {
            Console.WriteLine("Enter a number with three digits");
        }
    }
}