public class Sem1Task5 {

    static void Main(string[] args) // Показать вторую цифру трёхзначного числа
    {
        int number = int.Parse(Console.ReadLine());
        if (number >= 100 && number < 1000) // whether the number is three-digit
        {
            Console.WriteLine(number/10 % 10);
        }
        else
        {
            Console.WriteLine("Enter a number with three digits");
        }
    }
}
