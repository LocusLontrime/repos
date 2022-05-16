public class GoingToZeroOrToInfinity
{
    static void Main(string[] args)
    {
        Console.WriteLine(Going(100000));
    }

    public static double Going(int n)
    {
        // your code
        double sum = 0;
        double currRevFuck = 1;

        for (int i = n; i > 0; i--) 
        {           
            sum += currRevFuck;
            currRevFuck /= i;
        }

        return Math.Round(sum, 6);
    }
}