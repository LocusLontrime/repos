public class Task3 // Дано натульное число n > 1. Вывести все простые множители данного числа
{
    // обнаружен баг, метод был доработан в Factorization.sln

    static void Main(string[] args)
    {
        long number = 100000000000000; // a test case number

        SortedDictionary<long, int> factorDictionary = factorizationFast(number); // method call

        int counter = 0;

        Console.Write("Factorization of " + number + ": ");

        foreach (KeyValuePair<long, int> pair in factorDictionary) // just printing of the factorization dictionary
        {
            counter++;
            if (counter != factorDictionary.Count) Console.Write(pair.Key + "^" + pair.Value + " * ");
            else Console.Write(pair.Key + "^" + pair.Value);
        }

        Console.WriteLine("\nThe overall number of distinct devisors: " + counter);
    }

    public static SortedDictionary<long, int> factorizationFast(long number) // works fast, there are some problems when number = bigPrime1 * bigPrime2,
                                                                             // where bigPrime1 and bigPrime2 are almost equal to each other
    {
        SortedDictionary<long, int> factorDictionary = new SortedDictionary<long, int>();
        int innerCounter;
        bool flag;

        List<int> primes = new List<int>(); // the list of prime numbers, which is being built in the process of factorization
        primes.Add(2);

        for (int i = 2; i <= Math.Sqrt(number) + 1; i++) // a restriction, coz if the number has no devisors that are less than or equal to
                                                         // the square root of the number -> the number is Prime; and there no devisors exist that are larger than
                                                         // square root of the number...)
        {
            flag = true;
            foreach (int j in primes) // checks if the number is prime or not
            {
                if (i % j == 0)
                {
                    flag = false;
                    break;
                }

                if (i * i > number) break; // a familiar rescriction from above
            }

            if (flag || i == 2) // if the current devisor is prime and is not equal to 2 (initially located to the list)
            {
                primes.Add(i); // adding the prime number to the Primes list

                innerCounter = 0;
                while (number != 1 && number % i == 0) // counting the power of current prime devisor
                {
                    number /= i;
                    innerCounter++;
                }

                if (innerCounter >= 1) factorDictionary.Add(i, innerCounter); // if the power is larger than or equals to 1 ->
                                                                              // the current devisor is added to the dictionary

                if (number == 1) return factorDictionary; // if the number is now equals to 1 -> the factorization is over,
                                                          // so we cat return the dictionary built
            }
        }

        return factorDictionary;
    }
}