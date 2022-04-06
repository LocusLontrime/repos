public class AddTask2 // Двумерный массив размером 3х4 заполнен числами от 100 до 9999.
                      // Найдите в этом массиве и сохраните в одномерный массив все числа,
                      // сумма цифр которых больше их произведения. Выведите оба массива
{
    static void Main(string[] args)
    {
        int[,] array = new int[3, 4];

        RandomFill(100, 10000, array);

        int[] result = GetNumbers(array);

        Console.WriteLine("result length: " + result.Length);

        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }

    public static int[] GetNumbers(int[,] array) 
    {
        List<int> list = new List<int>();

        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if(IsDigitsSumLarger(array[j, i])) list.Add(array[j, i]);
            }
        }

        return list.ToArray();
    }

    public static bool IsDigitsSumLarger(int num) 
    {
        int sum = 0, mult = 1;
        int currDigit;

        while (num > 0)
        {
            currDigit = num % 10;

            sum += currDigit;
            mult *= currDigit;

            num /= 10;
        }

        return sum > mult;
    }

    public static void RandomFill(int min, int max, int[,] array) 
    {
        Random r = new Random();

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = r.Next(min, max + 1);
            }
        }
    }
}