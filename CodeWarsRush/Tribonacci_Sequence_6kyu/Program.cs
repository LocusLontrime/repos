public class TribonacciSequence 
{
    static void Main(string[] args)
    {
        Console.WriteLine(String.Join(" ", Tribonacci(new double[] { 0, 0, 1 }, 9)));
    }

    public static double[] Tribonacci(double[] signature, int n)
    {
        double fib_1before = signature[2], fib_2before = signature[1], fib_3before = signature[0];

        double[] result = new double[n];

        for (int i = 0; i < Math.Min(signature.Length, n); i++) 
        { 
            result[i] = signature[i];
        }

        for (int i = signature.Length; i < n; i++)
        {
            fib_1before = fib_1before + fib_2before + fib_3before;
            fib_2before = fib_1before - fib_2before - fib_3before;
            fib_3before = fib_1before - fib_2before - fib_3before;

            result[i] = fib_1before;
        }

        return result;
    }
}