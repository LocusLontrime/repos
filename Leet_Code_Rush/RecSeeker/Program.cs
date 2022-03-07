public class RecSeeker // sum of digits
{
    public static void Main(string[] args)
    {
        Console.WriteLine(RecursiveSeeker(123456789));
    }
    public static int RecursiveSeeker(int number) => number > 0 ? number % 10 + RecursiveSeeker(number / 10) : 0;   
}