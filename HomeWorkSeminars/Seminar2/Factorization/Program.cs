public class Factorization // Случайно оказалось здесь.)
{
    public static void Main(string[] args) // factorization of 124 -> 2 * 2 * 31
    {
        long number = 100000000000000;

        SortedDictionary<long, int> factorDictionary = factorizationFast(number);

        int counter = 0;

        Console.Write("Factorization of " + number + ": ");

        foreach (KeyValuePair<long, int> pair in factorDictionary)       
        {
            counter++;
            if (counter != factorDictionary.Count) Console.Write(pair.Key + "^" + pair.Value + " * ");
            else Console.Write(pair.Key + "^" + pair.Value);
        }

        /* List<int> primes = primesSearch(number);

        Console.WriteLine();

        Console.Write("Primes before " + number + ": ");

        foreach (int i in primes) Console.Write(i + " "); */
    }

    public static SortedDictionary<long, int> factorization(long number) // works if number is less than 1000
    {   
        SortedDictionary<long, int> factorDictionary = new SortedDictionary<long, int>();
        List<int> primes = primesSearch((int) Math.Sqrt(number) + 1);
        
        int innerCounter;

        for (int i = 0; i < primes.Count; i++)
        {
            innerCounter = 0;
            while (number != 1 && number % primes[i] == 0)
            {
                number /= primes[i];
                innerCounter++;
            }

            if (innerCounter >= 1) factorDictionary.Add(primes[i], innerCounter);

            if (number == 1) break;
        }

        if (factorDictionary.Count == 0) factorDictionary.Add(number, 1);
        
        return factorDictionary;
    }

    public static SortedDictionary<long, int> factorizationFast(long number) // works faster, problems when number = bigPrime1 * bigPrime2, where
                                                                             // bigPrime1 and bigPrime2 are almost equal to each other
    {
        SortedDictionary<long, int> factorDictionary = new SortedDictionary<long, int>();
        int innerCounter;
        bool flag;

        List<int> primes = new List<int>();
        primes.Add(2);

        for (int i = 2; i <= Math.Sqrt(number) + 1; i++)
        {
            flag = true;
            foreach (int j in primes)
            {
                if (i % j == 0)
                {
                    flag = false;
                    break;
                }

                if (i * i > number) break;
            }

            if (flag || i == 2) { 
                primes.Add(i);

                innerCounter = 0;
                while (number != 1 && number % i == 0)
                {
                    number /= i;
                    innerCounter++;
                }

                if (innerCounter >= 1) factorDictionary.Add(i, innerCounter);

                if (number == 1) return factorDictionary;
            }
        }

        return factorDictionary;
    }

    public static List<int> primesSearch(int number)   
    {
        bool flag;        

        List<int> primes = new List<int> ();
        primes.Add(2);

        for (int i = 3; i <= number; i++) 
        {
            flag = true;
            foreach (int j in primes) 
            {
                if (i % j == 0) {
                    flag = false;
                    break;
                }

                if (i * i > number) break;
            }

            if(flag) primes.Add(i);
        }

        return primes;
    }
}