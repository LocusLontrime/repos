public class Task2 // Двумерный массив заполнен случайными натуральными числами от 1 до 10.
                   // Найдите количество элементов, значение которых больше 5, и их сумму
{
    static void Main(string[] args)
    {
        int[,] array2D = new int[7, 9];
        RandomFillArray2D(array2D, 1, 10);
        int[] result = QuantityAndSum(array2D, 5);
        Console.WriteLine($"Sum of elements: {result[0]}, elements quantity: {result[1]}");
    }

    public static void RandomFillArray2D(int[,] array2D, int n, int m) 
    { 
        Random random = new Random();

        for (int j = 0; j < array2D.GetLength(0); j++)        
            for (int i = 0; i < array2D.GetLength(1); i++)
                array2D[j, i] = random.Next(n, m + 1);                 
    }

    public static int[] QuantityAndSum(int[,] array2D, int pivot) // this operations can be written in the method above for a better runtime,
                                                                  // but it could break the task logic,
                                                                  // at first an array is given -> then we do some calcs
    {
        int sum = 0, counter = 0;

        for (int j = 0; j < array2D.GetLength(0); j++)
            for (int i = 0; i < array2D.GetLength(1); i++)
                if (array2D[j, i] > pivot)
                { 
                    sum += array2D[j, i]; 
                    counter++;
                }

        return new int[] { sum, counter };
    }
}