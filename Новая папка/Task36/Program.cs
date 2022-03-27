// Определение рандомного массива

public class Task36
{
    static void Main(string[] args)
    {
        int[] array = RandomArray();
    }

    public static int[] RandomArray()
    {

        int[] array = new int[10];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(0, 1000);
        }

        // Вывод полученого массива

        Console.WriteLine("Вывод суммы с нечетными индексами массива");
        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {

            if (i % 2 != 0)
            {
                j += array[i]; ;
            }
        }
        Console.WriteLine(j);
        return array;
    }
}