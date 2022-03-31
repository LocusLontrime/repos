public class Task34 // Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу,
                    // которая покажет количество чётных чисел в массиве
{
    static void Main(string[] args)
    {
        int[] array = GetArray();

        Console.WriteLine("Array length: " + array.Length);

        PrintEvensQuantity(array);
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

    public static void PrintEvensQuantity(int[] array)
    {
        int counter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0) counter++;
        }

        Console.WriteLine("Evens quantity: " + counter);
    }
}