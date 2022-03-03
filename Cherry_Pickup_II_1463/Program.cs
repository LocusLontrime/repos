public class CherryPickupII1463 // accepted (speed: 104ms, fast, beats 90,97% of C# submissions)
{

    public static int[,,] memoTable; // memoTable for dynamic programming

    static void Main(string[] args)
    {
        int[,] grid = new int[,] { { 1, 0, 0, 0, 0, 0, 1 }, { 2, 0, 0, 0, 0, 3, 0 }, { 2, 0, 9, 0, 0, 0, 0 }, {0, 3, 0, 5, 4, 0, 0 }, { 1, 0, 2, 3, 0, 0, 6 } };

        Console.WriteLine(CherryPickup(grid)); // base method call     
    }

    public static int CherryPickup(int[,] grid) // base method
    {
        memoTable = new int [grid.GetLength(0), grid.GetLength(1), grid.GetLength(1)]; // initialization of memoTable

        // Console.WriteLine("columns: " + grid.GetLength(0) + " rows: " + grid.GetLength(1)); // checking

        for (int i = 0; i < grid.GetLength(0); i++) 
            for (int j = 0; j < grid.GetLength(1); j++) 
                for (int k = 0; k < grid.GetLength(1); k++) 
                    memoTable[i, j, k] = -1;     

        return recursiveSeeker(0, 0, grid.GetLength(1) - 1, grid); // first recursive call
    }

    public static int recursiveSeeker(int i, int j, int k, int[,] grid) // recursive dynamic programming nethod
    {
        if (j < 0 || j >= grid.GetLength(1) || k < 0 || k >= grid.GetLength(1)) return 0; // if we are out of range

        if (memoTable[i, j, k] != -1) return memoTable[i, j, k]; // if current step has already been calculated then
                                                                 // we just use its cashed in the memoTable value

        int result = 0; // sum of next step max cherries number and max cherries picked up at the current step

        result += grid[i, j]; // we always add a first robot's number of picked up cherries

        if (j != k) result += grid[i, k]; // if robots do not stay in the same cell we add two heap of cherries to the result

        if (i != grid.GetLength(0) - 1) // when we are not out of range in terms of columns
        {
            int maxNextStepCherriesNumber = 0; // max cherries number on the next step

            for (int newJ = j - 1; newJ <= j + 1; newJ++) // cycling over all possible next-step cells (1st robot)
            {
                for (int newK = k - 1; newK <= k + 1; newK++) // cycling over all possible next-step cells (2nd robot)
                {
                    maxNextStepCherriesNumber = Math.Max(maxNextStepCherriesNumber, recursiveSeeker(i + 1, newJ, newK, grid)); // searching for the max
                                                                                                                               // next step cherries number
                }
            }

            result += maxNextStepCherriesNumber; // getting the result
        }

        return memoTable[i, j, k] = result; // return memoTable value
    }

}