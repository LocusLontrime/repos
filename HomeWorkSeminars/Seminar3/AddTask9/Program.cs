public class AddTask9 // Напишите программу, который выводит на консоль таблицу умножения от 1 до n, где n задаётся случайно от 2 до 100
{
    public static void Main(string[] args)
    {
        PrintMultiplicationTable();
    }

    public static void PrintMultiplicationTable() // printing method, some formatting
    { 
        Random random = new Random();

        int n = random.Next(2, 100);

        int length = (int)Math.Log10(n * n) + 1;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int currentNumberLength = (int)Math.Log10(i * j) + 1;
                Console.Write(i * j);
                for (int k = 0; k <= length - currentNumberLength; k++) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}