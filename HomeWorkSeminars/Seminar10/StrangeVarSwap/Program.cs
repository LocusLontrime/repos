public class StrangeVarSwap // Поменять значения двух натуральных числе, используя только рекурсию и декремент с инкрементом.
{
    static void Main(string[] args)
    {
        SwapVars(98, 99);

        Console.WriteLine("\nRec sum: " + RecSum(7, 15, 0) + ", Rec substraction: " + RecSubstraction(17, 5)); // tests
    }

    public static void SwapVars(int a, int b) // cannot work for immutable vars (so for illustration we're using printing),
                                              // but could perfectly work for two array elements
    {
        Console.WriteLine($"Before the method call: a = {a}, b = {b}\n");

        a = RecSum(a, b, 0); // a familiar method of swapping the vars
        b = RecSubstraction(a, b);
        a = RecSubstraction(a, b);

        Console.WriteLine($"After the method call: a = {a}, b = {b}");
    }

    public static int RecSum(int a, int b, int result) // sum with rec and incrementation and decrementation
    {
        if (a == 0 && b == 0) return result;
        if (a > 0 && b > 0) return RecSum(--a, b, ++result);
        else return RecSum(a, --b, ++result);
    }

    public static int RecSubstraction(int a, int b) // substraction with rec and decrementation
    {
        if (a == 0) return b;
        else if (b == 0) return a;
        else return RecSubstraction(--a, --b);
    }

}