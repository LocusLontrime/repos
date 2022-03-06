public class TheMaze490 
{
    public static bool flag;

    public static readonly int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, -1 }, { 0, 1 } };

    static void Main(string[] args)
    {
        int[,] maze = new int[,] { { 0, 0, 1, 0, 0 },{ 0, 0, 0, 0, 0 },{ 0, 0, 0, 1, 0 },{ 1, 1, 0, 1, 1 },{ 0, 0, 0, 0, 0 } };

        Console.WriteLine(HasPath(maze, new int[] { 0, 4 }, new int[] { 4, 4 }));

        //PrintArray2D(maze);

        //Console.WriteLine();

        //PrintArray2D(NewMaze(maze));

        //Console.WriteLine();
    }

    public static bool HasPath(int[,] maze, int[] start, int[] destination)
    {
        flag = false;

        destination[0]++;
        destination[1]++;

        start[0]++;
        start[1]++;

        Dfs(start[0], start[1], NewMaze(maze), destination);
        return flag;
    }

    public static void Dfs(int j, int i, int[,] maze, int[] destination) // depth-first search
    {
        int jMax = maze.GetLength(0);
        int iMax = maze.GetLength(1);

        for (int k = 0; k < 4; k++)
        {
            while (i >= 0 && j >= 0 && j < jMax && i < iMax && maze[j, i] != 1) 
            {
                j += directions[k, 0];
                i += directions[k, 1];              
            }

            Console.WriteLine("Coordinates: (" + j + "," + i + ")");

            if (i > 0 && j > 0) i--; j--; // !&!&!

            if (j == destination[0] && i == destination[1]) flag = true;

            if (maze[j, i] == 2) continue;

            maze[j, i] = 2;

            Dfs(j, i, maze, destination);
        }
    }

    public static int[,] NewMaze(int[,] maze) 
    {
        int jMax = maze.GetLength(0);
        int iMax = maze.GetLength(1);

        int[,] newMaze = new int[jMax + 2, iMax + 2];

        for (int j  = 0; j < jMax; j++)      
            for (int i = 0; i < iMax; i++)           
                newMaze[j + 1, i + 1] = maze[j, i];

        for (int i = 0; i < iMax + 2; i++)
            newMaze[0 , i] = 1;

        for (int i = 0; i < iMax + 2; i++)
            newMaze[iMax + 1, i] = 1;

        for (int j = 0; j < jMax + 2; j++)
            newMaze[j, 0] = 1;

        for (int j = 0; j < jMax + 2; j++)
            newMaze[j, jMax + 1] = 1;

        return newMaze;
    }
    public static void PrintArray2D(int[,] array) 
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++) Console.Write(array[j, i] + " ");
            Console.WriteLine();
        }               
    }
}