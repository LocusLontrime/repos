public class AddTask2 // На вход подаются два числа случайной длины.
                      // Найдите произведение каждого разряда первого числа на каждый разряд второго.
                      // Ответ запишите в массив
{
    static void Main(string[] args)
    {
        int[,] array = GetMultiplications(123, 5367);
       

        PrintArray2D(array);
    }

    public static int[,] GetMultiplications(int num1, int num2) 
    { 
        List<int> list1 = GetDigits(num1);
        List<int> list2 = GetDigits(num2);

        int[,] array = new int[list1.Count, list2.Count];

        for (int i = 0; i < list1.Count; i++) 
        {
            for (int j = 0; j < list2.Count; j++) 
            { 
                array[i, j] = list1[i] * list2[j];
            }
        }

        return array;
    }

    public static List<int> GetDigits(int number)
    {
        List<int> digits = new List<int>();

        while (number > 0)
        {
            digits.Add(number % 10);
            number /= 10;
        }

        digits.Reverse();

        return digits;
    }

    public static void PrintArray2D(int[,] array) 
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write(array[j, i] + " ");
            }
            Console.WriteLine();
        }
    }
}