public class AddTask3 // Найдите все числа от 1 до 1000000, сумма цифр которых
                      // в три раза меньше их произведений. Подсчитайте их количество
{
    static void Main(string[] args)
    {
        FindNumbers();
    }

    public static void FindNumbers() 
    {
        List<int> list;

        List<int> result = new List<int>();

        int sum, multiplication;

        for (int i = 1; i <= 1000000; i++) 
        {
            list = GetDigits(i);

            sum = 0;
            multiplication = 1;

            foreach (var item in list) 
            {
                sum += item;

                multiplication *= item;

                if (multiplication == sum * 3) result.Add(i);
            }
        }

        Console.WriteLine("Numbers quantity: " + result.Count + "\n");

        foreach (var item in result) 
        {
            Console.Write(item + " ");
        }
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