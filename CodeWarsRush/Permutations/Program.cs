public class Permutations // 
{
    public static List<string> sets = new List<string>();
    public static int N;

    static void Main(string[] args)
    {
        PermuteUnique("ab");

        // PrintPermutations();

        foreach (var item in sets)
        {
            Console.WriteLine(item);
        }
    }

    public static List<string> PermuteUnique(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>(); // dictionary initialization

        N = s.Length; // nums length

        foreach (var i in s) // dictionary building
        {
            if (map.ContainsKey(i)) map[i]++;
            else map.Add(i, 1);
        }

        RecursiveSeeker(map, String.Empty, s); // recursive invocation

        return sets;
    }

    public static void RecursiveSeeker(Dictionary<char, int> map, string elements, string s)
    {
        if (elements.Length == N) sets.Add(elements); // adding the result found to the List of Lists

        foreach (var kvp in map) // cycling all over the existing elements
        {
            if (map[kvp.Key] != 0) // if the counter of current element has fallen to Zero
            {
                Dictionary<char, int> currMap = new Dictionary<char, int>(map);

                elements += kvp.Key; // adding a new nums element to List
                currMap[kvp.Key]--;

                RecursiveSeeker(currMap, elements, s); // recursiveSeeker invocation

                elements = elements.Remove(elements.Length - 1); // backtracking
                currMap[kvp.Key]++;

                map = new Dictionary<char, int>(currMap);
            }
        }
    }

    public static void PrintPermutations() // auxiliary method for printing results
    {
        foreach (string i in sets)
        {
            Console.Write("(");
            for (int j = 0; j < i.Length; j++) Console.Write(i[j] + (j != i.Length - 1 ? "," : ")"));
            Console.WriteLine();
        }
    }
}
