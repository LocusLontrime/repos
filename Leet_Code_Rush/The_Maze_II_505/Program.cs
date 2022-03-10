public class TheMazeII505 // accepted (speed: > 500 and < 600ms, very low)
{
    public static readonly int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, -1 }, { 0, 1 } };
    static int[,] memoTable;
    static void Main(string[] args)
    {
        int[,] maze = new int[,] { { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 0 }, { 1, 1, 0, 1, 1 }, { 0, 0, 0, 0, 0 } };
      
         maze = new int[,] { // some test-cases
            { 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 0 } }; 

        int[] startPoint = new int[] { 0, 4 };
        int[] endPoint = new int[] { 4, 4 };

        // endPoint = new int[] { 3, 2 };

         startPoint = new int[] { 0, 0 };
         endPoint = new int[] { 8, 6 };

        Console.WriteLine("\n" + ShortestDistance(maze, startPoint, endPoint));

        // PrintArray2D(maze);

        //Console.WriteLine();

        //PrintArray2D(NewMaze(maze));

        //Console.WriteLine();
    }

    public static int ShortestDistance(int[,] maze, int[] start, int[] destination) // starting method
    {                   
        Console.WriteLine("Start point: (" + start[0] + "," + start[1] + ")\n");

        memoTable = new int[maze.GetLength(0), maze.GetLength(1)];

        Array2Dfullfil(memoTable);
        memoTable[start[0], start[1]] = 0;

        Dfs(start[0], start[1], maze, destination); // start rec dfs 

        // PrintArray2D(memoTable);

        return memoTable[destination[0], destination[1]] == int.MaxValue ? -1 : memoTable[destination[0], destination[1]];       
    }

    public static void Dfs(int j, int i, int[,] maze, int[] destination) // depth-first search
    {       
        int jMax = maze.GetLength(0); // height an width of an array
        int iMax = maze.GetLength(1);      

        for (int k = 0; k < 4; k++) // cycling all over the four directions
        {
            int curr_j = j; // current coordinates
            int curr_i = i;

            //curr_j += directions[k, 0]; // initial increasing ???
            //curr_i += directions[k, 1];

            while (curr_i >= 0 && curr_j >= 0 && curr_j < jMax && curr_i < iMax && maze[curr_j, curr_i] != 1) // cycling increasing
            {
                curr_j += directions[k, 0]; // here the ball is moving in the direction chosen untill hits the wall (1 in a maze matrix representation)
                curr_i += directions[k, 1];
            }

            curr_j -= directions[k, 0]; // decreasing (tuning)
            curr_i -= directions[k, 1];

            int currPath = Math.Abs(curr_j - j) + Math.Abs(curr_i - i);

            // Console.WriteLine("curr_j = " + curr_j + " curr_i = " + curr_i);

            if (memoTable[j, i] + currPath < memoTable[curr_j, curr_i]) 
            {              
                memoTable[curr_j, curr_i] = memoTable[j, i] + currPath;
                Dfs(curr_j, curr_i, maze, destination); // recall of rec dfs
            }                  
        }
    }
    public static void PrintArray2D(int[,] array) // auxiliary merhod for printing a 2D - array of memoTable
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++) Console.Write(array[j, i] == int.MaxValue ? "M " : array[j, i] + " ");
            Console.WriteLine();
        }
    }

    public static void Array2Dfullfil(int[,] array) 
    {
        for (int i = 0; i < array.GetLength(0); i++)       
            for (int j = 0; j < array.GetLength(1); j++)            
                array[i, j] = int.MaxValue;                 
    }
}