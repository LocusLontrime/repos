public class ANumberAfterDoubleReversal2119 
{

    static void Main(string[] args) // accepted (speed: 32ms, very fast, beats 93,26% of java submissions) 
    {
        Console.WriteLine(IsSameAfterReversals(1800));
    }

    public static bool IsSameAfterReversals(int num)
    {
        int oldNumber = num;
        int newNumber = 0;

        while (num > 0)
        { // 12345 -> 54321
            newNumber *= 10;
            newNumber += num % 10;
            num /= 10;
        }

        num = newNumber;
        newNumber = 0;

        while (num > 0)
        { // 12345 -> 54321
            newNumber *= 10;
            newNumber += num % 10;
            num /= 10;
        }

        Console.WriteLine("oldNumber = " + oldNumber + " newNumber = " + newNumber);

        return newNumber == oldNumber;
    }
}
