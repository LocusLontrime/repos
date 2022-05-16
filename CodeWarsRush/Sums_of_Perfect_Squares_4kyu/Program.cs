public class SumsOfPerfectSquares
{
    static void Main(string[] args)
    {
        // FuckYourComp();

        Console.WriteLine(NSquaresFor(13));
    }

    public static int NSquaresFor(int n)
    {
        // Your code here!

        int intSqrt = (int) Math.Sqrt(n);

        if (intSqrt * intSqrt == n) return 1;

        for (int i = 0; i <= intSqrt + 1; i++)       
        {
            int currDiff = n - i * i;
            int currSqrt = (int)Math.Sqrt(currDiff);
            if (currSqrt * currSqrt == currDiff) return 2;
        }

        while (n % 4 == 0) n /= 4;

        if (n % 8 == 7) return 4;

        return 3;
    }

    public static void FuckYourComp() 
    {
        for (int i = 0; i < 1000000000 + 1; i++);
    }
}