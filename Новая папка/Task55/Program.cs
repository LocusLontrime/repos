using LibZett;

public class Task55 // Дан целочисленный массив. Найти среднее арифметическое каждого из столбцов
{
    static void Main(string[] args)
    {
        int[,] array = Library.GetRandomArray2D(5, 7);

        Library.PrintArray2D(array);

        Find(array);
    }

    public static void Find(int[,] array) 
    {
        int tempSum;

        for (int i = 0; i < array.GetLength(0); i++) //  цикл по строкам
        {
            tempSum = 0;

            for (int j = 0; j < array.GetLength(1); j++) //  цикл по столбцам
            {
                tempSum += array[i, j];
            }

            Console.WriteLine((i + 1) + "-th Arithmetic Mean = " + tempSum / array.GetLength(1));
        }
    }
}