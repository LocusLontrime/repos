using System.Diagnostics;
using System.Linq;

public class GettingAlongWithIntegerPartitions 
{
    public static HashSet<List<int>> partitionsSet = new HashSet<List<int>>();
    public static long recCounter;

    static void Main(string[] args)
    {


        Console.WriteLine(Part(5));

    }

















    public static string Part(long n) // n <= 50
    {
        //your code
        partitionsSet = new HashSet<List<int>>();

        RecursiveSeeker((int) n, (int) n, new List<int>());

        SortedSet<int> products = new SortedSet<int>();

        foreach (var item in partitionsSet) 
        {
            var product = item.Aggregate(1, (a, b) => a * b);
            products.Add(product);
        }

        int[] prods = products.ToArray();
        int length = prods.Length;

        int range = prods[length - 1] - prods[0];
        double average = prods.Average();
        double median;

        if (length % 2 != 0) median = prods[length / 2];
        else median = (prods[(length - 1) / 2] + prods[(length + 1) / 2]) / 2.0; 
        
        return $"Range: {range} Average: {string.Format("{0:0.00}", average)} Median: {string.Format("{0:0.00}", median)}";
    }

    public static void RecursiveSeeker(int rem, int prevPart, List<int> list) 
    {
        recCounter++;

        // base case
        if (rem == 0) 
        {
            // addition of a current partition to the set of partitions
            partitionsSet.Add(list);
        }

        // body of recursion
        for (int i = 1; i <= prevPart; i++) 
        {
            // element (part) addition
            list.Add(i);

            // recurrent relation
            if(rem - i >= 0) RecursiveSeeker(rem - i, i, new List<int> (list));

            // bactracking
            list.Remove(i);
        }
    }
}