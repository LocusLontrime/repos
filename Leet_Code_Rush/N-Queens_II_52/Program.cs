public class NQueensII52 // accepted (36ms, fast enough, beats 70,54% of C# submissions) then (after submission) we added placements printing!!!
{
    public static int N;
    public static HashSet<HashSet<KeyValuePair<int, int>>> set = new HashSet<HashSet<KeyValuePair<int, int>>>();

    static void Main(string[] args)
    {
        Console.WriteLine("All placements number: " + TotalNQueens(5) + "\n");

        Console.WriteLine("All placements Queens coordinates:\n");

        foreach (var set in set) 
        {
            foreach (var kvp in set) Console.Write("(" + kvp.Key + "," + kvp.Value + ") ");
            Console.WriteLine();
        }
    }

    public static int TotalNQueens(int n) 
    {
        N = n;

        Console.WriteLine("N = " + N);

        return RecursiveSeeker(0, new List<int>(), new HashSet<int>(), new HashSet<int>());
    }

    public static int RecursiveSeeker(int row, List<int> verticalSet, HashSet<int> diag1Set, HashSet<int> diag2Set) // List -> only for printing
                                                                                                                    // the placements queens coordinates
    {
        if (row == N) {
            HashSet<KeyValuePair<int, int>> currSet = new HashSet<KeyValuePair<int, int>>();

            int currRow = 0;
            foreach (int i in verticalSet) currSet.Add(new KeyValuePair<int, int>(currRow++, i));

            set.Add(currSet);

            return 1; 
        }

        int count = 0;

        for (int i = 0; i < N; i++)
        {
            if (!verticalSet.Contains(i) && !diag1Set.Contains(row + i) && !diag2Set.Contains(row - i)) {              

                List<int> newVerticalSet = new List<int>(verticalSet);
                HashSet<int> newDiag1Set = new HashSet<int>(diag1Set);
                HashSet<int> newDiag2Set = new HashSet<int>(diag2Set);

                newVerticalSet.Add(i);
                newDiag1Set.Add(row + i);
                newDiag2Set.Add(row - i);

                count += RecursiveSeeker(row + 1, newVerticalSet, newDiag1Set, newDiag2Set);
            }
        }  
        
        return count;
    }
}