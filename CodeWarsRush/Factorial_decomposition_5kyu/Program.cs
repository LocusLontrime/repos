using System.Diagnostics;
using System.Text;

public class Factorial_decomposition_5kyu // accepted on codewars.com
{
    public static SortedDictionary<long, int> factorDictionary = new SortedDictionary<long, int>();

    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        // String result = Decomp(17);

        string result = Decomp(5000000);

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        foreach (var item in factorDictionary)
        {
            Console.WriteLine($"{item.Key}^{item.Value}");
        }

        Console.WriteLine("\n" + result); 

        /*

        Console.WriteLine(); 

        factorDictionary.Clear();

        factorizationFast(17 * 17 * 3);

        foreach (var item in factorDictionary)
        {
            Console.WriteLine($"{item.Key}^{item.Value}");
        } */
    }

    public static string Decomp(int n)
    {
        StringBuilder s = new StringBuilder("");

        for (int i = 2; i <= n; i++)
        {
            factorizationFast((long) i);       
        }

        foreach (var item in factorDictionary) 
        {
            if (item.Value != 1) s.Append($"{item.Key}^{item.Value} * ");
            else s.Append($"{item.Key} * ");
        }

        s.Remove(s.Length - 3, 3);

        factorDictionary.Clear();

        return s.ToString();
    }

    public static void factorizationFast(long number) 
    {       
        int innerCounter;
        bool flag; 

        long fixNumber = number;

        List<int> primes = new List<int>();
        
        for (int i = 2; i * i <= fixNumber; i++)
        {
            flag = true;

            foreach (int j in primes)
            {
                if (i % j == 0)
                {
                    flag = false;
                    break;
                }

                if (i * i > fixNumber) break; // ???
            }

            if (flag || i == 2)
            {
                primes.Add(i);

                innerCounter = 0;

                while (number != 1 && number % i == 0)
                {
                    number /= i;
                    innerCounter++;
                }               

                if (innerCounter >= 1) 
                {
                    if (factorDictionary.ContainsKey(i)) 
                    { 
                        factorDictionary[i] += innerCounter;
                    }
                    else factorDictionary.Add(i, innerCounter);
                }

                if (number == 1) return;
            }
        }

        if (number == fixNumber) 
        {
            if (factorDictionary.ContainsKey(fixNumber)) factorDictionary[fixNumber]++;
            else factorDictionary.Add(fixNumber, 1);
        }
        else
        {
            factorizationFast(number);
        }
    }
}
