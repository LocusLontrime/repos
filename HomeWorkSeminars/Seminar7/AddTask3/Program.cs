public class AddTaskRec 
{
    public static bool flag;
    static void Main(string[] args) 
    {
        // An easy additional task from Seminar7
        // Runtime difficulty (the worst case of a grid filled with only 1s): O(n * m), algo requires a constant additional memory: O(1)
        //true condition
        int[,] grid = new int[,] { { 1, 1, 1, 0, 1 }, { 0, 0, 1, 0, 1 }, { 0, 1, 1, 0, 1 }, { 0, 1, 1, 1, 1 }, { 0, 0, 1, 0, 1 } };
        Console.WriteLine(FindTheWay(grid));
        //false condition
        grid = new int[,] { { 1, 1, 1, 0, 1 }, { 0, 0, 1, 0, 1 }, { 0, 1, 0, 0, 1 }, { 0, 1, 1, 1, 1 }, { 0, 0, 1, 0, 1 } };
        Console.WriteLine(FindTheWay(grid));
    }

    public static bool FindTheWay(int[,] grid) 
    {
        flag = false; // initial flag position
        RecursiveSeeker(0, 0, grid); // here the recursion starts
        return flag; // returning of the flag bool value
    }

    public static void RecursiveSeeker(int j, int i, int[,] grid) 
    {   // border cases and checking that the player is moving forward and not returning
        if (i < 0 || j < 0 || i >= grid.GetLength(1) || j >= grid.GetLength(0) || grid[j, i] == 0) return;
        // reaching the destination point and flag changing
        if (i == grid.GetLength(1) - 1 && j == grid.GetLength(0) - 1) flag = true;
        // way back prohibition
        grid[j, i] = 0;
        // recursive calls -> further moving
        RecursiveSeeker(j - 1, i, grid);
        RecursiveSeeker(j + 1, i, grid);
        RecursiveSeeker(j, i + 1, grid);
        RecursiveSeeker(j, i - 1, grid);
    }
}