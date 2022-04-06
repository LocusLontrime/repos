public class Task52 // Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце
{
    static void Main(string[] args)
    {
        int[,] array = new int[,] { {1, 2, 3, 44 }, {98, 55, 67, 99 }, { 0, 1, 0, 87}, { 19, 29, 89, 97} };

        GetArithmeticMeans(array);
    }

    public static void GetArithmeticMeans(int[,] array) 
    {
        double sum;

        for (int j = 0; j < array.GetLength(0); j++)
        {
            sum = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[j, i];
            }

            Console.WriteLine($"{j}th row's Arithmetic mean: {sum / array.GetLength(1)}");
        }
    }
}