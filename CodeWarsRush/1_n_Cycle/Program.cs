public class Cycle1n
{

    static void Main(string[] args) // accepted on codewars.com
    {

        decimal k = 1.0m / 17;

        Console.WriteLine(k);

        Console.WriteLine(Running(17));

    }

    public static int Running(int n)
    {
        int currVal = 1;
        int iterator = 0;

        while (true) 
        {
            iterator++;

            currVal = (currVal * 10) % n;

            if (currVal == 1) break;
        }

        return iterator;
    }
}