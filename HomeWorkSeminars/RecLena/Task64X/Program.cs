public class Task64X // Задача 64: Задайте значения M и N. Напишите программу,
                     // которая выведет все натуральные числа кратные 3-ём в промежутке от M до N
{

    static void Main(string[] args)
    {
        PrintRec(1, 98);
    }

    public static void PrintRec(int M, int N) // optimized
    {
        // border case
        if (M == N + 1) return;

        //do phase
        if (M % 3 == 0)
        {
            Console.Write(M + " ");

            // recursive call
            PrintRec(M + 3, N);
        }
        else
        {
            // recursive call
            PrintRec(M + 1, N);
        }
    }
}