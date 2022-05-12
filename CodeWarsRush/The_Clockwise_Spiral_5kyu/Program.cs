public class TheClockwiseSpiral // accepted codewars.com
{
    public static List<int[]> directions = new List<int[]>()
    {
        new int[] { 0, 1 },
        new int[] { 1, 0 },
        new int[] { 0,-1 },
        new int[] { -1,0 }
    };

    public static int jMax, iMax;

    static void Main(string[] args)
    {

        print_2D_array(CreateSpiral(45));

    }

    public static int[,] CreateSpiral(int N)
    {
        int[,] matrix =  new int[N, N];

        return SpiralOrderAlt(matrix);
    }

    public static int[,] SpiralOrderAlt(int[,] matrix)
    {
        jMax = matrix.GetLength(0);
        iMax = matrix.GetLength(1);
        ZeroFill(matrix);

        SpiralOrderRec(0, 1, 0, 0, matrix);

        return matrix;
    }

    public static void SpiralOrderRec(int counter, int num, int j, int i, int[,] matrix)
    {
        matrix[j, i] = num; // filling
        int jD = directions[counter % 4][0]; // deltas for next step Coords
        int iD = directions[counter % 4][1];

        if (counter > 2 * Math.Min(jMax, iMax)) return; // approx stop condition
                                                        // 
                                                        // forward branch
        if (j + jD >= 0 && i + iD >= 0 && j + jD < jMax && i + iD < iMax && matrix[j + jD, i + iD] == 0) SpiralOrderRec(counter, num + 1, j + jD, i + iD, matrix);
        else SpiralOrderRec(counter + 1, num, j, i, matrix); // direction change branch
    }

    public static void ZeroFill(int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[j, i] = 0;
    }

    public static void print_2D_array(int[,] array) // enhanced printing method, it prints the array in a more convenient way
    { // auxiliary method for 2D array printing

        int maxValue = array.GetLength(0) * array.GetLength(1);
        int length = (int)Math.Log10(maxValue) + 1;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int currentNumberLength = (int)Math.Log10(array[i, j]) + 1;
                Console.Write(array[i, j]);
                for (int k = 0; k <= length - currentNumberLength; k++) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
