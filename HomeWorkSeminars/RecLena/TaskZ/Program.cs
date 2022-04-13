public class iLoveLena // Задайте значения M и N. Напишите программу,
                       // которая найдёт сумму натуральных элементов в промежутке от M до N
{

    static void Main(string[] args)
    {
        Console.WriteLine(FindSumRec(1, 5));
    }

    public static int FindSumRec(int M, int N) 
    { 
        // border case
        if (M == N + 1) return 0;

        // do phase -> nothing

        // reccurent relation
        return FindSumRec(M + 1, N) + M;
    }
}