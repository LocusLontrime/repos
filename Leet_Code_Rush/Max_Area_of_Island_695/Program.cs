public class MaxAreaofIsland694 // accepted (speed: 88ms, incredibly fast, beats 97,61% of C# submissions) 
{
    public static int volumeCounter;

    public static bool[,] visitedCells;

    public static int maxVolume = 0;

    static void Main(string[] args)
    {

        int[,] grid = new int[,] { { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },{0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },{0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },{0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },{0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0} };

        Console.WriteLine(MaxIsland(grid));
    }

    public static int MaxIsland(int[,] grid)
    {
        visitedCells = new bool[grid.GetLength(0), grid.GetLength(1)];

        for (int j = 0; j < grid.GetLength(0); j++) // visited cells array initial fullfilling
            for (int i = 0; i < grid.GetLength(1); i++)
                visitedCells[j, i] = false;

        for (int j = 0; j < grid.GetLength(0); j++) // cycling all over the grid
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                // Console.WriteLine("j = " + j + " i = " + i);
                if (!visitedCells[j, i] && grid[j, i] == 1)
                {
                    volumeCounter = 0;
                    FindIslandVolume(grid, j, i); // calculating the volume of all the islands 
                    Console.WriteLine("The volume of the island being processed: " + volumeCounter);
                    maxVolume = Math.Max(maxVolume, volumeCounter); // write the max value in maxVolume
                }
            }

        return maxVolume; // return the max volume
    }

    public static void FindIslandVolume(int[,] grid, int j, int i)
    {
        if (i < 0 || j < 0 || j >= grid.GetLength(0) || i >= grid.GetLength(1) || // stop-conditional
            visitedCells[j, i] == true || grid[j, i] == 0) return;

        // Console.WriteLine("j = " + j + " i = " + i); // printing intermediate results

        visitedCells[j, i] = true;

        volumeCounter++; // counts colume of the current island

        FindIslandVolume(grid, j - 1, i); // moving upwards
        FindIslandVolume(grid, j + 1, i); // moving downwards
        FindIslandVolume(grid, j, i + 1); // moving to the right
        FindIslandVolume(grid, j, i - 1); // moving to the left        
    }
}