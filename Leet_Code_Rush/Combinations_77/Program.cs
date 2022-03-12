public class Combinations77 
{
    public static IList<IList<int>> sets = new List<IList<int>> (); // accepted (speed: 92ms, very fast)
    public static int n;
    public static int k;

    static void Main(string[] args)
    {
        Combine(15, 5); PrintCombinations(); // main method call (exlp366mv)   
    }
    public static IList<IList<int>> Combine(int n, int k)
    {
        Combinations77.n = n; Combinations77.k = k;
        RecursiveSeeker(1, new List<int>());
        return sets;
    }
    public static void RecursiveSeeker(int startingElement, List <int> currSet) 
    {
        if (currSet.Count == k) sets.Add(new List<int>(currSet)); // if the length of a List is equal to k then we add it to result List of Lists
             
        for (int i = startingElement; i <= n; ++i) // cycling all over the combinations, we're building them in such way that the repeated ones
       // are throwed away automatically 4ex: 123 and 231, there allowed only one permutation where the digits are being increased sequentially
        {            
            currSet.Add(i); // adding a new element to it
            RecursiveSeeker(i + 1, currSet); // making a recursive call with a newCurrentSet and starting with the incremented by 1 first element
            currSet.RemoveAt(currSet.Count - 1); // bactracking
        }
    }
    public static void PrintCombinations() // auxiliary method for printing results
    {
        foreach (List<int> i in sets)
        {
            Console.Write("("); foreach (int j in i) Console.Write(j + (!j.Equals(i[i.Count - 1]) ? "," : ")")); Console.WriteLine();
        }
    }
}