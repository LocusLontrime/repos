public class PermutationsII47 // accepted (speed: 136ms, very fast, beats 92,12% of C# submissions)
{
    public static IList<IList<int>> sets = new List<IList<int>>(); 
    public static int N;

    static void Main(string[] args)
    {
        PermuteUnique(new int[] { 1, 1, 2 });

        PrintPermutations();        
    }

    public static IList<IList<int>> PermuteUnique(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>(); // dictionary initialization

        N = nums.Length; // nums length

        foreach (int i in nums) // dictionary building
        {
            int temp;
            if (map.ContainsKey(i)) map[i]++;  
            else map.Add(i, 1);
        }
      
        RecursiveSeeker(map, new List<int>(), nums); // recursive invocation

        return sets;
    }

    public static void RecursiveSeeker(Dictionary<int, int> map, List<int> elements, int[] nums)
    {
        if (elements.Count == N) sets.Add(new List<int>(elements)); // adding the result found to the Lisf of Lists
        
        foreach (var kvp in map) // cycling all over the existing elements
        {           
            if (map[kvp.Key] != 0) // if the counter of current element has fallen to Zero
            {
                elements.Add(kvp.Key); // adding a new nums element to List
                map[kvp.Key]--;
                              
                RecursiveSeeker(map, elements, nums); // recursiveSeeker invocation

                elements.RemoveAt(elements.Count - 1); // backtracking
                map[kvp.Key]++;                
            }
        }       
    }

    public static void PrintPermutations() // auxiliary method for printing results
    {
        foreach (List<int> i in sets)
        {
            Console.Write("("); 
            for (int j = 0; j < i.Count; j++) Console.Write(i[j] + (j != i.Count - 1 ? "," : ")")); 
            Console.WriteLine();
        }
    }    
}