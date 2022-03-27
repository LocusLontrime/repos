using LibZett;
public class ArraySmth // 1. найти сумму элементов с четными индексами строк и сбтолбцов
                       // 2. найти максимальное произведние двух элементов матрицы (i != j)
{
    static int firstMaxIndexI = int.MaxValue, firstMaxIndexJ = int.MaxValue;

    static void Main(string[] args)
    {
        int[,] array = Library.GetRandomArray2D(5, 5);

        Library.PrintArray2D(array);

        // DoSmth(array);

        Console.WriteLine(FindMaxMultiplication(array));
       
    }

    public static void DoSmth(int[,] array) // 1
    {
        int sum = 0;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (i % 2 == 0 && j % 2 == 0)
                {
                    sum += array[i, j];
                }
            }
        }

        Console.WriteLine($"Sum = {sum}");
    }

    public static int FindMaxMultiplication(int[,] array) // 2, for 2 elements
    {
        int max1 = FindMaxElement(array);
        int max2 = FindMaxElement(array);

        Console.WriteLine(max1 + " " + max2);

        return max1 * max2;
    }

    public static int FindMaxElement(int[,] array) 
    {
        int max = int.MinValue;
        bool flag = firstMaxIndexI == int.MaxValue;        
        
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (flag) 
                { 
                    if (array[i, j] > max)
                    {
                        firstMaxIndexI = i;
                        firstMaxIndexJ = j;
                    }

                    max = Math.Max(max, array[i, j]);
                }
                else if (firstMaxIndexI != i && (firstMaxIndexJ != j)) 
                {                   
                    max = Math.Max(max, array[i, j]);
                } 
            }
        }

        return max;
    }
}