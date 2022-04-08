public class Task66 // Задайте значения M и N. Напишите программу,
                    // которая найдёт сумму натуральных элементов в промежутке от M до N
{
    static void Main(string[] args)
    {
        Console.WriteLine(SumRecCalc(1, 100, 0));
    }

    public static int SumRecCalc(int M, int N, int currSum) => M > N ?  currSum : SumRecCalc(M + 1, N, currSum + M);    
}