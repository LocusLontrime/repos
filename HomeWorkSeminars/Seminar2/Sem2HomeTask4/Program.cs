public class Sem2HomeTask4 // По двум заданным числам проверять является ли одно квадратом другого
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        if (num1 == num2 * num2) Console.WriteLine(num1 + " equals " + num2 + " squared");
        else if (num2 == num1 * num1) Console.WriteLine(num2 + " equals " + num1 + " squared");
        else Console.WriteLine("nothing special");
    }
}