public class AddTAsk1 // Даны два числа a, b. Сложите их, используя только операции инкремента и декремента
{
    static void Main(string[] args)
    {
        Console.WriteLine(RecSum(89, 98, 0));
    }

    public static int RecSum(int m, int n, int result) // Akkerman Edition
    {
        if (n == 0 && m == 0) return result;

        if (m > 0) return RecSum(m - 1, n, ++result);
        else return RecSum(m, n - 1, ++result);
    }
}