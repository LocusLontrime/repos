public class Task47 // Задайте двумерный массив размером m×n,
                    // заполненный случайными вещественными числами
{
    public static Random random = new Random();

    public static int maxNumber;

    static void Main(string[] args)
    {
        double[,] grid = GetRandomNumbersArray(10, 10, 1000);

        PrintArray2D(grid);
    }

    public static double[,] GetRandomNumbersArray(int m, int n, int maxNumber)
    {
        Task47.maxNumber = maxNumber;

        double[,] grid = new double[m, n];

        RecursiveFilling(0, 0, grid); // here the recursion starts

        return grid;
    }

    public static void RecursiveFilling(int j, int i, double[,] grid) // why not?..)
    {
        //base cases:
        if (j == grid.GetLength(0) - 1 && i == grid.GetLength(1) - 1) return;

        grid[j, i] = maxNumber * random.NextDouble();

        if (i == grid.GetLength(1) - 1)
        {
            RecursiveFilling(j + 1, 0, grid);
        }
        else
        {
            RecursiveFilling(j, i + 1, grid);
        }
    }

    public static void NonRecursiveFilling(double[,] grid) // not so interesting as a rec one is...
    {
        for (int j = 0; j < grid.GetLength(0); j++)
        {
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                grid[j, i] = maxNumber * random.NextDouble();
            }
        }
    }

    public static void PrintArray2D(double[,] grid) // just printing
    {
        for (int j = 0; j < grid.GetLength(0); j++)
        {
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                Console.Write((int) grid[j, i] + " ");
            }
            Console.WriteLine();
        }
    }
}