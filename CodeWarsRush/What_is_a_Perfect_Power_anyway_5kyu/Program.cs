public class PerfectPower // accepted on codewars.com
{
    static void Main(string[] args)
    {

        Console.WriteLine(IsPerfectPower(243));

    }

    public static (int, int)? IsPerfectPower(int n)
    {
        for (int i = 2; i <= (int) Math.Sqrt(n); i++) 
        { 
            int log = (int) Math.Round(Math.Log(n, i));

            Console.WriteLine(Math.Log(n, i));

            Console.WriteLine($"i = {i}, log = {log}");

            if (log > 1 && (int)Math.Pow(i, log) == n) return (i, log);
        }

        return null;
    }
}