public class Task38 // Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива
{
    static void Main(string[] args)
    {
        double[] array = GetArray();

        Console.WriteLine(Delta(array));
    }

    public static double[] GetArray()
    {
        Random random = new Random();

        double[] array = new double[random.Next(10, 101)];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 1000 * random.NextDouble();
        }

        return array;
    }

    public static double Delta(double[] array) // {1, 2, 3, 4, 5}
    {
        double min = double.MaxValue, max = double.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            min = Math.Min(min, array[i]);
            max = Math.Max(max, array[i]);
        }

        return max - min;
    }
}