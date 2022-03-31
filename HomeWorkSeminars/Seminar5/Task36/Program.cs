public class Task36 // Задайте одномерный массив, заполненный случайными числами.
                    // Найдите сумму элементов, стоящих на нечётных позициях
{
    static void Main(string[] args)
    {
        int[] array = GetArray();
        PrintArray1D(array);
        Console.WriteLine("\nOdds sum: " + SumOfOdds(array));
    }

    public static int[] GetArray()
    {
        Random random = new Random();

        int[] array = new int[random.Next(10, 101)];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(100, 1000);
        }

        return array;
    }

    public static int SumOfOdds(int[] array) 
    {
        int sum = 0;

        for (int i = 1; i < array.Length; i+=2)
        {
            sum += array[i]; 
        }

        return sum;
    }

    public static void PrintArray1D(int[] array) 
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}