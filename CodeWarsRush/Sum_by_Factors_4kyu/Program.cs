public class SumByFactors // accepted on codewars.com
{
    public static int maxAbsNumber;
    public static SortedDictionary<int, int> sumByFactors = new SortedDictionary<int, int>();
    static void Main(string[] args)
    {
        Console.WriteLine(SumOfDivided(new int[] { 12, -10, 15 }));
    }

    public static string SumOfDivided(int[] lst)
    {
        maxAbsNumber = 0;
        string res = "";
        sumByFactors = new SortedDictionary<int, int>();
        GetMaxAbsNumber(lst);

        HashSet<int> primes = GetPrimes((int) Math.Sqrt(maxAbsNumber));

        foreach (var number in lst) 
        {
            GetDistinctPrimeFactors(number, primes);
        }

        foreach(var kvp in sumByFactors) 
        {
            res += $"({kvp.Key} {kvp.Value})";
        }

        return res;
    }

    // add all the new prime factors to the map with increasing the corresponding sums
    public static void GetDistinctPrimeFactors(int element, HashSet<int> primes)
    {
        int elementItself = element;
        element = Math.Abs(element);

        foreach(var prime in primes) 
        {
            if (element % prime == 0) {

                while (element % prime == 0) 
                {
                    element /= prime;
                }

                if (sumByFactors.ContainsKey(prime))
                {
                    sumByFactors[prime] += elementItself;
                }
                else 
                { 
                    sumByFactors.Add(prime, elementItself);
                }
            }

            if (element == 1) break;
        }

        if (element != 1)
        {
            if (sumByFactors.ContainsKey(element))
            {
                sumByFactors[element] += elementItself;
            }
            else
            {
                sumByFactors.Add(element, elementItself);
            }
        }
    }

    // an auxiliary method that finds max abs number in the array given 
    public static void GetMaxAbsNumber(int[] array) {foreach(var item in array) maxAbsNumber = Math.Max(maxAbsNumber, Math.Abs(item));}
      
    // an auxiliary method: Eratosthenes' sieve, using for searching primes from 2 to the number given

    public static HashSet<int> GetPrimes(int n) 
    {
        List<int> numbers = new List<int>();

        int i = 0;
        while (i <= n) numbers.Add(i++);
        
        numbers[1] = 0; // 1 is a first prime number

        // we begin from 3-rd element
        i = 2;
        while (i <= n)
        {
            // if the cell's value has not yet been nullified -> it keeps the prime number
            if (numbers[i] != 0) 
            {
                // the first multiple will me two times large (thus we exclude the primes)
                int j = i + i;
                while (j <= n)
                { 
                    // not a prime -> exchange it with 0
                    numbers[j] = 0;

                    // now proceeding to the next number (n % i == 0)
                    // it has a value that is larger by i

                    j += i;
                }
            }

            i++;
        }

        HashSet<int> primesSet = new HashSet<int>(numbers);

        primesSet.Remove(0);

        return primesSet;
    }
}