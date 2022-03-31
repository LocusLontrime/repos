public class Task27 // Напишите программу, которая принимает на вход число и выдаёт
                    // сумму цифр в числе.
{
    static void Main(string[] args)
    {
        Console.WriteLine(DigitsSum(1948576369));
        Console.WriteLine(DigitsSum("1948576369"));
    }

    public static int DigitsSum(int number) 
    {
        int sum = 0;

        while (number > 0) 
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }

    public static int DigitsSum(string number)
    {
        int sum = 0;

        foreach (char str in number)
        {
            sum += (int) char.GetNumericValue(str);
        }

        return sum;
    }
}