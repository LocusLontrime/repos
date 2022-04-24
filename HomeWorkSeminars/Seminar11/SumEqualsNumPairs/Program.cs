public class SumEqualsNumPairs // найти все пары элементов массива, сумма которых равна заданному числу N // 36 
{
    static void Main(string[] args)
    {
        int[] array = new int[] { 2, 3, 4, 6, 7, 8, 9, 10, 12, 15, 98 };
        int target = 15;

        FindAllThePairs(array, target);

        Console.WriteLine("\n");

        int count = 1;

        foreach (var item in FindAllTriplets(array, target)) 
        {
            Console.WriteLine($"{count++}-th triplet:\n");

            foreach (var pair in item) 
            {
                Console.WriteLine($"value: {pair.Key} at index: {pair.Value}");
            }
        }
    }

    public static void FindAllThePairs(int[] array, int sum) // O(n) runtime approx
    { 
        Dictionary<int, int> indexMap = new Dictionary<int, int>();

        int counter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (!indexMap.ContainsKey(array[i]))
            {
                if (indexMap.ContainsKey(sum - array[i])) Console.WriteLine($"{counter++}-th pair: ({array[i]}, {sum - array[i]})");

                indexMap.Add(array[i], i);

                if (indexMap.ContainsKey(sum - array[i])) Console.WriteLine($"  at indexes: ({indexMap[array[i]]}, {indexMap[sum - array[i]]})");
            }
        }
    }

    public static List<Dictionary<int, int>> FindAllTriplets(int[] array, int sum) 
    {
        Dictionary<int, int> indexMap = new Dictionary<int, int>();

        List<Dictionary<int, int>> resultListOfTriplets = new List<Dictionary<int, int>>();      
        
        for (int i = 0; i < array.Length; i++)
        {                      
            List <Dictionary<int, int>> currListOfPairs = FindAllThePairsAuxiliary(array, i + 1, sum - array[i]); 

            if (currListOfPairs.Count > 0)
            {
                foreach (Dictionary<int, int> innerPair in currListOfPairs)
                {
                    innerPair.Add(array[i], i);
                }

                resultListOfTriplets.AddRange(currListOfPairs);
            }           
        }

        return resultListOfTriplets;
    }

    public static List<Dictionary<int, int>> FindAllThePairsAuxiliary(int[] array, int startIndex, int sum)
    {
        List<Dictionary<int, int>> pairs = new List<Dictionary<int, int>>();

        Dictionary<int, int> indexMap = new Dictionary<int, int>();

        for (int i = startIndex; i < array.Length; i++)
        {
            if (!indexMap.ContainsKey(array[i]))
            {
                if (indexMap.ContainsKey(sum - array[i]) && sum - array[i] != array[i])
                {
                    Dictionary<int, int> currPair = new Dictionary<int, int>();

                    currPair.Add(array[i], i);
                    currPair.Add(sum - array[i], indexMap[sum - array[i]]);

                    pairs.Add(currPair);                    
                }

                indexMap.Add(array[i], i);
            }
        }
            
        return pairs;
    }

    public static List<Dictionary<int, int>> FindAllValElementsSums(int[] array, int k, int sum)
    { 



    }
}