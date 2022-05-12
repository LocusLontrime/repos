public class MakeSpiral // accepted on codewars.com
{
    public static List<int[]> directions = new List<int[]>()
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };

    public static int jMax, iMax;

    static void Main(string[] args)
    {
        int input = 98;

        int[,] expected = new int[,]{
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };

        Print_2D_array(Spiralize(15));
    }

    public static int[,] Spiralize(int size)
    {
        int[,] spiral = new int[size, size];

        SpiralOrderAlt(spiral);

        return spiral;
    }

    public static void SpiralOrderAlt(int[,] matrix)
    {
        jMax = matrix.GetLength(0);
        iMax = matrix.GetLength(1);
        ZeroFill(matrix);
        SpiralOrderRec(0, 0, 0, matrix);
    }

    public static void SpiralOrderRec(int counter, int j, int i, int[,] matrix)
    {
        matrix[j, i] = 1; // filling
        int jD = directions[counter % 4][0]; // deltas for next step Coords
        int iD = directions[counter % 4][1];

        if (counter > 2 * Math.Min(jMax, iMax)) return; // approx stop condition
                                                        // 
                                                        // forward branch
        if (IsValid(j, i, jD, iD) && matrix[j + jD, i + iD] == 0) 
        {
            if (IsValid(j, i, 2 * jD, 2 * iD) && matrix[j + 2 * jD, i + 2 * iD] == 1)
            {
                SpiralOrderRec(counter + 1, j, i, matrix);
            }
            else if (matrix[j + jD + directions[(counter + 1) % 4][0], i + iD + directions[(counter + 1) % 4][1]] != 1) SpiralOrderRec(counter, j + jD, i + iD, matrix); 
        }
        else SpiralOrderRec(counter + 1, j, i, matrix); // direction change branch
    }

    public static bool IsValid(int j, int i, int jD, int iD) 
    {
        return j + jD >= 0 && i + iD >= 0 && j + jD < jMax && i + iD < iMax;
    }

    public static void ZeroFill(int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[j, i] = 0;
    }

    public static void Print_2D_array(int[,] array) // auxiliary method for 2D array printing
    { 
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();                                                         
        }
    }
}