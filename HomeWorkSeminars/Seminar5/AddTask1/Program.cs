public class AddTask1 // Задан массив из случайных цифр на 15 элементов.
                      // На вход подаётся трёхзначное натуральное число.
                      // Напишите программу, которая определяет, есть в массиве
                      // последовательность из трёх элементов, совпадающая с введённым числом
{
    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 2, 6, 7, 9, 8, 1, 2, 3, 5, 5, 6, 7, 9, 8, 9, 9};

        Console.WriteLine(IsThereNumberInArray(123, array));

        List<int> list = GetDigits(123456789); // just checking

        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
    }

    public static bool IsThereNumberInArray(int number, int[] array) 
    {
        List<int> digits = GetDigits(number);

        bool flag;

        for (int i = 0; i < array.Length - digits.Count + 1; i++) 
        {
            flag = true;

            for (int j = 0; j < digits.Count; j++) 
            { 
                if (array[i + j] != digits[j]) flag = false;
            }

            if (flag) return true;
        }

        return false;
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
}