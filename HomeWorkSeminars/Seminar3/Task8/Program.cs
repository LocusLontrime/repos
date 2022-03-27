public class Task8 //  Напишите программу, которая на вход
                   //  принимает число (N), а на выходе
                   //  показывает все чётные числа от 1 до N
{

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number N: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 2; i <= N; i = i + 2) // i += 2 то же самое
        {
            Console.Write(i + " ");
        }

    }



}