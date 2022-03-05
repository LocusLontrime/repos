using System.Text;

public class NumberOfDistinctIslands694 
{
    public static StringBuilder islandHash;

    public static bool[,] visitedCells;

    public static HashSet<string> set;

    static void Main(string[] args)
    {

        int[,] grid = new int[,] { { 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 1, 0 }, { 0, 1, 1, 1, 0 }, { 0, 0, 0, 0, 0 } };
        grid = new int[,] { { 1, 1, 0, 1, 1 },{ 1, 0, 0, 0, 0 },{ 0, 0, 0, 0, 1 },{ 1, 1, 0, 1, 1 } };
        grid = new int[,] { { 1, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };

    Console.WriteLine(NumDistinctIslands(grid));

        foreach (string s in set) Console.WriteLine(s); 
    }

    public static int NumDistinctIslands(int[,] grid)
    {
        visitedCells = new bool[grid.GetLength(0), grid.GetLength(1)];

        set = new HashSet<string>();

        for (int j = 0; j < grid.GetLength(0); j++) 
            for (int i = 0; i < grid.GetLength(1); i++) 
                visitedCells[j, i] = false;

        for (int j = 0; j < grid.GetLength(0); j++)
            for (int i = 0; i < grid.GetLength(1); i++) 
            {
                // Console.WriteLine("j = " + j + " i = " + i);
                if (!visitedCells[j, i] && grid[j, i] == 1) 
                {                   
                    islandHash = new StringBuilder("");
                    hashIsland(grid, j, i, 'T'); // all the islands begins with the letter 'T"
                    Console.WriteLine("Hash of the island being processed: " + islandHash);
                    set.Add(islandHash.ToString());
                }
            }

        return set.Count;
    }

    public static void hashIsland(int[,] grid, int j, int i, char hashSymbol) 
    {
        if (i < 0 || j < 0 || j >= grid.GetLength(0) || i >= grid.GetLength(1) ||
            visitedCells[j, i] == true || grid[j, i] == 0) return;

        Console.WriteLine("j = " + j + " i = " + i);

        visitedCells[j, i] = true;

        islandHash.Append(hashSymbol);

        hashIsland(grid, j - 1, i, 'T');
        hashIsland(grid, j + 1, i, 'D');
        hashIsland(grid, j, i + 1, 'R');
        hashIsland(grid, j, i - 1, 'L');
    }
}