public class ReverseInteger7
{

    public static void Main(string[] args) // accepted (speed: 24ms, fast enough, beats 91,73% of c# submissions)
    {
        Console.WriteLine(Reverse(-123));
    }

    public static int Reverse(int x)
    {
        int oldNumber = x;
        long newNumber = 0;

        while (Math.Abs(x) > 0)
        { // 12345 -> 54321
            newNumber *= 10;
            newNumber += x % 10;
            x /= 10;
        }

        Console.WriteLine("newNumber = " + newNumber);

        if (newNumber > int.MaxValue || newNumber < int.MinValue) return 0;
        else return (int) newNumber;
    }
}