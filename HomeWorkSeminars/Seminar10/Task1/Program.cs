public class Task1 // Дано число n. Получите число, записанное в обратном порядке
{

    static void Main(string[] args)
    {
        ReverseNumber(153, 0);
    }

    public static void ReverseNumber(int number, int result)
    {
        // border(base) case
        if (number == 0)
        {
            Console.WriteLine(result); // printing the result
            return;
        }

        // do phase
        result = result * 10 + number % 10;

        // recursive call
        ReverseNumber(number / 10, result);
    }
}