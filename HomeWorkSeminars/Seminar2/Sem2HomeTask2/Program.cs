public class Sem2HomeTask2v // Показать четные числа от 1 до N
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 2; i <= number; i += 2) Console.Write(i + " ");
    }
}