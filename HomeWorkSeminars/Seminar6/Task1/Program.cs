public class Task1 // Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь
{
    static void Main(string[] args)
    {
        Console.WriteLine(CountPositiveIntegers(9));
    }

    public static int CountPositiveIntegers(int M) 
    {
        int count = M;
        int countPositive = 0;

        Console.WriteLine($"Please enter {M} numbers: \n");

        while (M > 0) 
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                M--;
                if (number > 0) countPositive++;
            }
            catch (Exception)
            {
                Console.WriteLine($"Please enter a number, {M} ones remained");
            }
        }

        return countPositive;
    }
}