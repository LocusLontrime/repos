public class Task32 // Напишите программу, которая принимает на вход число (N)
                    // и выдаёт таблицу кубов чисел от 1 до N
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number N:");
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            if (i != N) Console.Write(i * i * i + ", ");
            else Console.WriteLine(i * i * i + ".");
        }

    }

}