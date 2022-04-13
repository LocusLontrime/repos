public class Task64 // Задайте значения M и N. Напишите программу,
                    // которая выведет все натуральные числа кратные 3-ём в промежутке от M до N
{
    static void Main(string[] args)
    {
        PrintThoseOnesRec(15, 36, 3); // case of 3
        PrintThoseOnesRec(1, 989, 92); // case of 98
    }

    public static void PrintThoseOnesRec(int M, int N, int devisor) 
    {
        if (M > N) 
        {
            Console.WriteLine();
            return;
        }

        if (M % devisor != 0) PrintThoseOnesRec(M + 1, N, devisor);
        else
        {
            Console.Write(M + " ");
            PrintThoseOnesRec(M + devisor, N, devisor);
        }
    }
}