public class AddTask3 // Даны натуральные числа a и b. Рекурсивно описать функцию возведения
                      // числа a в степень b, используя только операцию инкрементирования (“++”)
{
    static void Main(string[] args)
    {
        //Pow(9, 9, 9, 9, 3, 0);

        Power(9, 3);

        Console.WriteLine("result = " + SecretRecursion(8, 3, 2));

        // Console.WriteLine(RecSum(5, 6, 0));
    }
    public static void Power(int a, int b) // covering
    {
        Pow(a, a, a, a, b, 0);
    }

    public static void Pow(int currA, int a, int currB, int b, int c, int result) // too much recursion
    {
        // border case
        if (c == 1)
        {
            Console.WriteLine($"result = " + currA);
            return;
        }
   
        if (currB == 0) 
        {
            Pow(result, result, b, b, c - 1, 0);
            return;
        }

        // recursive call
        if (currA > 0) Pow(currA - 1, a, currB, b, c, ++result);
        else Pow(a, a, currB - 1, b, c, result);
    }
    public static int SecretRecursion(int m, int n, int p) // 3-symbols Akkerman, too much recursion
    {
        if (p == 0) return RecSum(m, n, 0);
        else if (n == 0 && p == 1) return 0;
        else if (n == 0 && p == 2) return 1;
        else if (n == 0) return m;
        else return SecretRecursion(m, SecretRecursion(m, n - 1, p), p - 1);      
    }

    public static int RecSum(int m, int n, int result)
    {
        if (n == 0 && m == 0) return result;
        
        if (m > 0) return RecSum(m - 1, n, ++result);
        else return RecSum(m, n - 1, ++result);
    }
}