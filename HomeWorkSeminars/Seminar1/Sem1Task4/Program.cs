public class Sem1Task4 {

    public static void Main(string[] args) // Показать последнюю цифру трёхзначного числа
    {
        Console.WriteLine("Enter a three-digit number");
        int number = int.Parse(Console.ReadLine());
        if (number >= 100 && number < 1000) // whether the number is three-digit
        {
            Console.WriteLine("The last digit of the number is: " + number % 10);
        }
        else
        {
            Console.WriteLine("Enter a number with three digits");
        }
    }

}