using System.Collections;
using System.Text;

public class NumberOfDistinctIslandsII711 // 366
{
    public static int volumeCounter;   
    public static HashSet<string> uniqueIslands; // Set of unique Islands' representations
    public static List<int[]> currIslandCoordinates; // List of coordinate pairs for the every island in grid

    static void Main(string[] args)
    {
        int[,] grid = new int[,] { { 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1 },{ 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1 },
            {0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1 },{1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0 },{0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0 },
            { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1 },{0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1 },{0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0 }}; // test-case

        // grid = new int[,] { { 1, 1, 0, 0, 1 }, { 1, 0, 0, 1, 1 }, { 1, 1, 0, 1, 0 }, { 1, 0, 0, 1, 1 } };

         grid = new int[50, 50]; // more heavy benchmark...)
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = 1;
            }
        } 

        Console.WriteLine(NumDistinctIslands2(grid)); // method call
    }

    public static int NumDistinctIslands2(int[,] grid) // main method
    {    
        uniqueIslands = new HashSet<string>();        

        for (int j = 0; j < grid.GetLength(0); j++) // cycling all over the grid
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                // Console.WriteLine("j = " + j + " i = " + i);
                if (grid[j, i] == 1) // if the current cell has been already visited -> we should skip it
                {
                    currIslandCoordinates = new List<int[]>();
                    GetCoordinatesList(grid, j, i); // calculating the coordinates lists of all the islands 

                    // foreach (int[] pair in currIslandCoordinates) Console.WriteLine(pair[0] + " " + pair[1]);

                    Hashtable map = new Hashtable();

                    for (int m = 0; m < currIslandCoordinates.Count; m++) // cycling all over coordinates pairs within the current island
                    {
                        for (int n = m + 1; n < currIslandCoordinates.Count; n++)
                        {
                            int linkDistance = (int) Math.Pow(currIslandCoordinates[m][0] - currIslandCoordinates[n][0], 2) +
                                (int) Math.Pow(currIslandCoordinates[m][1] - currIslandCoordinates[n][1], 2);

                            // Console.WriteLine("Current distance = " + linkDistance);

                            if (map.ContainsKey(linkDistance))
                            {
                                var temp = map[linkDistance];
                                map.Remove(linkDistance);
                                map.Add(linkDistance, (int) temp + 1);
                            }
                            else map.Add(linkDistance, 1);
                        }
                    }

                    StringBuilder s = new StringBuilder("0"); // starting value for the island with one pair of coordinates
                    foreach (DictionaryEntry pair in map) s.Append(pair.Key).Append(pair.Value);

                    Console.WriteLine("island invariant hash = " + s.ToString());

                    uniqueIslands.Add(s.ToString());
                }
            }

        return uniqueIslands.Count; // return the number of distinctII islands
    }

    public static void GetCoordinatesList(int[,] grid, int j, int i) // gets the list od coordinates for the every cell of the island given
    {
        if (i < 0 || j < 0 || j >= grid.GetLength(0) || i >= grid.GetLength(1) || // stop-conditional
            grid[j, i] == 0) return;

        // Console.WriteLine("j = " + j + " i = " + i); // printing intermediate results

        grid[j, i] = 0;

        currIslandCoordinates.Add(new int[] { j, i }); // adding the coordinate pair to the list

        GetCoordinatesList(grid, j - 1, i); // moving upwards
        GetCoordinatesList(grid, j + 1, i); // moving downwards
        GetCoordinatesList(grid, j, i + 1); // moving to the right
        GetCoordinatesList(grid, j, i - 1); // moving to the left        
    }
}