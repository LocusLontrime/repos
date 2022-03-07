public class TheMaze490 
{
    public static bool flag;

    public static readonly int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, -1 }, { 0, 1 } };
    static void Main(string[] args)
    {
        int[,] maze = new int[,] { { 0, 0, 1, 0, 0 },{ 0, 0, 0, 0, 0 },{ 0, 0, 0, 1, 0 },{ 1, 1, 0, 1, 1 },{ 0, 0, 0, 0, 0 } };

        maze = new int[,] {
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
       
        endPoint = new int[] { 3, 2 };

        startPoint = new int[] { 0, 0 };
        endPoint = new int[] { 8, 6 };

        Console.WriteLine(HasPath(maze, startPoint, endPoint));

        //PrintArray2D(maze);

        //Console.WriteLine();

        //PrintArray2D(NewMaze(maze));

        //Console.WriteLine();
    }

    public static bool HasPath(int[,] maze, int[] start, int[] destination)
    {
        flag = false;

        int[][] lab = new int[9][];

        destination[0]++; // dest point shift -> to a newMaze's coordinates
        destination[1]++;

        start[0]++; // start point shift -> to a newMaze's coordinates
        start[1]++;

        Console.WriteLine("Start point: (" + start[0] + "," + start[1] + ")");

        Dfs(start[0], start[1], NewMaze(maze), destination); // start rec dfs 
        return flag;
    }

    public static void Dfs(int j, int i, int[,] maze, int[] destination) // depth-first search
    {
        if (maze[j, i] == 2) return; // if we have already visited this cell

        maze[j, i] = 2;

        int jMax = maze.GetLength(0); // height an width of an array
        int iMax = maze.GetLength(1);        

        for (int k = 0; k < 4; k++) // cycling all over the four directions
        {
            int curr_j = j; // current coordinates
            int curr_i = i;
            while (curr_i > 0 && curr_j > 0 && curr_j < jMax - 1 && curr_i < iMax - 1 && maze[curr_j + directions[k, 0], curr_i + directions[k, 1]] != 1) 
            {
                curr_j += directions[k, 0]; // here the ball is moving in the direction chosen untill hits the wall (1 in a maze matrix representation)
                curr_i += directions[k, 1];              
            }

            Console.WriteLine("Coordinates: (" + curr_j + "," + curr_i + ")");

            // if (i > 0 && j > 0) i--; j--; // !&!&!

            if (curr_j == destination[0] && curr_i == destination[1]) flag = true; // if the ball stops in a destination cell     

            Dfs(curr_j, curr_i, maze, destination); // recall of rec dfs
        }
    }

    public static int[,] NewMaze(int[,] maze) // buiding a cage of 1s around the maze given
    {
        int jMax = maze.GetLength(0);
        int iMax = maze.GetLength(1);

        int[,] newMaze = new int[jMax + 2, iMax + 2];

        for (int j = 0; j < jMax; j++)      
            for (int i = 0; i < iMax; i++)           
                newMaze[j + 1, i + 1] = maze[j, i];

        for (int i = 0; i < iMax + 2; i++)
            newMaze[0 , i] = 1;

        for (int i = 0; i < iMax + 2; i++)
            newMaze[jMax + 1, i] = 1;

        for (int j = 0; j < jMax + 2; j++)
            newMaze[j, 0] = 1;

        for (int j = 0; j < jMax + 2; j++)
            newMaze[j, iMax + 1] = 1;

        return newMaze;
    }
    public static void PrintArray2D(int[,] array) // auxiliary merhod for printing a 2D - array
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++) Console.Write(array[j, i] + " ");
            Console.WriteLine();
        }               
    }
}