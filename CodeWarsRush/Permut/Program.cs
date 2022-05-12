public class Permut // accepted on codewars.com
{
    public static HashSet<string> sets; // accepted (speed: 116ms, ultra fast, beats 99,46% of C# submissions)
    public static int N;

    static void Main(string[] args)
    {
        foreach (var item in Permute("aabb")) Console.WriteLine(item);       
    }

    public static List<string> Permute(string s)
    {
        List<char> elementsToPermutation = new List<char>();

        sets = new HashSet<string>();

        N = s.Length;

        for (int i = 0; i < s.Length; i++) 
        { 
            elementsToPermutation.Add(s[i]);
        }

        RecursiveSeeker(String.Empty, elementsToPermutation);

        List<string> list = new List<string>();

        foreach (var item in sets)
        {
            list.Add(item);
        }

        return list;
    }

    public static void RecursiveSeeker(string elements, List<char> remainedElements)
    {
        if (elements.Length > N) return;
        if (elements.Length == N) sets.Add(elements);

        for (int i = 0; i < remainedElements.Count; i++)
        {
            elements += remainedElements[i];            

            List<char> newList = new List<char>(remainedElements);
            newList.RemoveAt(i);

            RecursiveSeeker(elements, newList);

            elements = elements.Remove(elements.Length - 1);
        }
    }        
}