public class Lena // Вывести на экран натуральные числа от 1 до N (заданного) в строку через пробел
{
    static void Main(string[] args)
    {
        PrintFor(98);

        Console.WriteLine();

        PrintRec(1, 98);
    }

    public static void PrintFor(int N) 
    {
        for (int i = 1; i <= N; i++) Console.Write(i + " ");      
    }

    public static void PrintRec(int n, int N) 
    {
        // border case
        if (n == N + 1) return;

        Console.Write(n + " ");

        // reccurent relation
        PrintRec(n + 1, N);
    }
}