public class Permutation46
{
    public static IList<IList<int>> sets = new List<IList<int>>(); // accepted (speed: 116ms, ultra fast, beats 99,46% of C# submissions)
    public static int N;

    static void Main(string[] args)
    {
        Permute(new int[] { 1, 2, 3});

        PrintPermutations();
    }

    public static IList<IList<int>> Permute(int[] nums)
    {
        N = nums.Length;
        RecursiveSeeker(new List<int>(), nums);
        return sets;
    }

    public static void RecursiveSeeker(List<int> elements, int[] nums) 
    {
        if (elements.Count == N) sets.Add(new List<int>(elements));

        for (int i = 0; i < N; i++)
        {
            if (!elements.Contains(nums[i])) 
            {
                elements.Add(nums[i]); // addition (calculation)
                RecursiveSeeker(elements, nums); // new recursive invocation
                elements.RemoveAt(elements.Count - 1); // backtracking
            }
        }
    }

    public static void PrintPermutations() // auxiliary method for printing results
    {
        foreach (List<int> i in sets)
        {
            Console.Write("("); foreach (int j in i) Console.Write(j + (!j.Equals(i[i.Count - 1]) ? "," : ")")); Console.WriteLine();
        }
    }

}