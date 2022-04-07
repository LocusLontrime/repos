public class Task56 // Задайте прямоугольный двумерный массив.
                    // Напишите программу, которая будет находить строку
                    // с наименьшей суммой элементов
{
    public static int minSumIndex;
    public static int minSum;
    static void Main(string[] args)
    {
        int[,] array = new int[,] 
        {
            { 99, 99, 99, 99, 99, 99},
            { 1, 1, 1, 1, 1, 1 },
            { 11, 44, 57, 67, 98, 99 },
            { 25, 67, 76, 25, 36, 78 },
            { 95, 94, 36, 75, 74, 90 },
            { 92, 90, 91, 65, 78, 99 }
        };

        Console.WriteLine(MinSumIndexFind(array));
    }

    public static int MinSumIndexFind(int[,] array) // main method that starts the recursion
    {
        minSum = int.MaxValue;
        minSumIndex = 0; 

        RecSeeker(0, 0, 0, array);

        Console.WriteLine("Min sum = " + minSum);

        return minSumIndex;
    }

    public static void RecSeeker(int j, int i, int sum, int[,] array) // just a recursion, it is all we need
    {
        if (j == array.GetLength(0)) return;
        if (i == array.GetLength(1))
        {
            if (sum < minSum) 
            {
                minSum = sum;
                minSumIndex = j;
            }

            RecSeeker(j + 1, 0, 0, array);
        }
        else 
        {
            RecSeeker(j, i + 1, sum + array[j, i], array);
        }
    }
}