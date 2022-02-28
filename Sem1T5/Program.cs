public class Sem1Task4
{
    static void Main(string[] args) // Показать последнюю цифру трёхзначного числа
    {
        Console.WriteLine("Enter some number");
        int num = int.Parse(Console.ReadLine());
        if (num >= 100 && num < 1000) // whether the number is three-digit
        {
            Console.WriteLine(num % 10);            
        }
        else
        {
            Console.WriteLine("Enter a number with three digits");
        }
    }
}