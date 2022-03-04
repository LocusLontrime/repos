public class Task27 
{ 
    static void Main(string[] args)
    {
        Console.WriteLine("Digits count = " + digitsCount(4));

        Console.WriteLine("Sum = " + MaxSumLessThanOrEqualToK(10000000));
    }

    public static int digitsCount(int number) // Определить количество цифр в числе
{
        if (number == 0) return 1;

        int counter = 0;

        while (number > 0) {
            number /= 10;
            counter++;
        }

        return counter;
    }

    public static int MaxSumLessThanOrEqualToK(int k) // + доп: максимальная сумма натурального ряда, меньшая, либо равная числу k
    {
        {
            int sum = 0;

            for (int i = 0; i <= k; i++)
            {
                sum += i;
                if (sum + i + 1 > k)
                {
                    Console.WriteLine("current i = " + i);
                    return sum;
                }
            }

            return 0;
        }
    }
}