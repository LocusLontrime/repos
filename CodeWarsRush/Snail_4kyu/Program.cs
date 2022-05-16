public class Snail // accepted on codewars
{

    public static List<int[]> directions = new List<int[]>()
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };

    public static int jMax, iMax;

    public static int[] snail;

    static void Main(string[] args)
    {
        int[,] matrix = new int[,]
        {
           {1, 2, 3},
           {4, 5, 6},
           {7, 8, 9}
        };

        Console.WriteLine(string.Join(" ", SpiralOrderAlt(matrix)));
    }

    public static int[] SpiralOrderAlt(int[,] matrix)
    {
        jMax = matrix.GetLength(0);
        iMax = matrix.GetLength(1);

        snail = new int[jMax * iMax];

        // ZeroFill(matrix);
        SpiralOrderRec(0, 0, 0, 0, matrix);

        return snail;
    }

    public static void SpiralOrderRec(int counter, int num, int j, int i, int[,] matrix)
    {
        if (matrix[j, i] != 0) 
        {
            snail[num] = matrix[j, i]; // filling       
            matrix[j, i] = 0; // memo
        }

        int jD = directions[counter % 4][0]; // deltas for next step Coords
        int iD = directions[counter % 4][1];

        if (counter > 2 * Math.Min(jMax, iMax)) return; // approx stop condition
                                                        //
                                                        // forward branch
        if (j + jD >= 0 && i + iD >= 0 && j + jD < jMax && i + iD < iMax && matrix[j + jD, i + iD] != 0) SpiralOrderRec(counter, num + 1, j + jD, i + iD, matrix);
        else SpiralOrderRec(counter + 1, num, j, i, matrix); // direction change branch
    } 
}