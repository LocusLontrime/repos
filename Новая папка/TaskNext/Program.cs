public class TaskNext {

    static void Main(string[] args)
    {
        double[] array = MethodAccessException();
    }
    public static double[] MethodAccessException()
    {
        double[] array = new double[10];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next();
        }

        Console.WriteLine("Вывод суммы с нечетными индексами массива");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
        return array;
    }

}