using System.Diagnostics;
using System.Text;

public class Factorial_decomposition_fast_5kyu {

    public static SortedDictionary<long, int> factorDictionary = new SortedDictionary<long, int>();

    public static List<long> primes = new List<long>();

    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        // String result = Decomp(17);

        string result = Decomp(50000);

        // factorizationFast(600851475143);

        foreach (var item in primes)
        {
            Console.WriteLine($"{item}");
        }

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        foreach (var item in factorDictionary)
        {
            Console.WriteLine($"{item.Key}^{item.Value}");
        }

        Console.WriteLine("\n" + result);
    }

    public static string Decomp(int n)
    {
        StringBuilder s = new StringBuilder("");

        for (int i = 2; i <= n; i++)
        {
            factorizationFast(i);
        }

        foreach (var item in factorDictionary)
        {
            if (item.Value != 1) s.Append($"{item.Key}^{item.Value} * ");
            else s.Append($"{item.Key} * ");
        }

        s.Remove(s.Length - 3, 3);

        factorDictionary.Clear();
        primes.Clear();

        return s.ToString();
    }

    public static void factorizationFast(long number)
    {
        int innerCounter;

        long fixNumber = number;       

        for (int i = 0; i < primes.Count && primes[i] * primes[i] <= fixNumber; i++)
        {
            innerCounter = 0;

            while (number != 1 && number % primes[i] == 0)
            {
                number /= primes[i];
                innerCounter++;
            }

            if (innerCounter >= 1)
            {
                if (factorDictionary.ContainsKey(primes[i]))
                {
                    factorDictionary[primes[i]] += innerCounter;
                }
                else factorDictionary.Add(primes[i], innerCounter);
            }

            if (number == 1) return;         
        }

        if (number == fixNumber)
        {        
            factorDictionary.Add(fixNumber, 1); // the number must be a prime one
            primes.Add(fixNumber);
        }
        else
        {
            // factorizationFast(number); // the number must be prime here, so as it is latger than sqrt(number) -> no need to dive into the recursuon
            if (factorDictionary.ContainsKey(number)) factorDictionary[number]++;
            else factorDictionary.Add(number, 1);
        }
    }
}