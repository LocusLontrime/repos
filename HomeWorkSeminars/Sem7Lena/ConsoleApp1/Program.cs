public class Task1 // Задайте двумерный массив размером m×n, заполненный случайными вещественными числами
{
    static void Main(string[] args)
    {
        double[,] matrix = RandomArrayFill(9, 7, 1000);

        PrintArray2D(matrix);
    }

    public static double[,] RandomArrayFill(int height, int width, int maxVal) // filling and initialization of the array
    { 
        Random random = new Random();

        double[,] result = new double[height, width];

        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                result[i, j] = maxVal * random.NextDouble();

        return result;
    }

    public static void PrintArray2D(double[,] array2D) // just printing
    {
        for (int i = 0; i < array2D.GetLength(0); i++)
        {
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
                Console.Write((int) array2D[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}