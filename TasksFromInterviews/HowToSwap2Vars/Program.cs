public class SwapTheVars 
{
    static void Main(string[] args)
    {

        int a = 8, b = 98;

        a = a ^ b;
        b = b ^ a;
        a = a ^ b;

        Console.WriteLine(a + " " + b);
    }
}