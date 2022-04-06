public class SpiralMatrix {

    public static List<int[]> directions = new List<int[]>()
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };

    public static int jMax, iMax;

    public static void Main(String[] args) {

        int[,] array = new int[65, 45];

        // print_2D_array(array);

        // Console.WriteLine();

        SpiralOrder(array); // cycle method call

        print_2D_array (array);

        foreach (var item in directions) 
        {
            Console.WriteLine("jDelta: " + item[0] + " iDelta = " + item[1]);
        }

        int[,] matrix = new int[35, 15];

        SpiralOrderAlt(matrix); // recursive method call

        print_2D_array (matrix);
    }

    public static void SpiralOrder(int[,] matrix) // fulfilling the matrix with the numbers in spiral order
    {
        int height = matrix.GetLength(0);
        int width = matrix.GetLength(1);

        int i = 0, j = 0, k = 1;

        int right_steps = 0, down_steps = 0, left_steps = 0, up_steps = 0;

        while (true) // outer cycle
        {
            while (i < width - 1 - down_steps) // top walking -> from left to right
            {
                matrix[j, i] = k;
                k++;
                i++;
            }

            if (i + 1 == width - down_steps && right_steps + left_steps + 1 == height) // here we stop, one of the stop-conditional
            {
                matrix[j, i] = k;
                break;
            }

            right_steps++;

            while (j < height - 1 - left_steps) // right walking -> from the top down
            {
                matrix[j, i] = k;
                k++;
                j++;
            }

            if (j + 1 == height - left_steps && up_steps + down_steps + 1 == width) // here we stop, one of the stop-conditional
            {
                matrix[j, i] = k;
                break;
            }

            down_steps++;

            while (i > up_steps) // bot walking -> from right to left
            {
                matrix[j,i] = k;
                k++;
                i--;
            }

            if (i == up_steps && right_steps + left_steps + 1 == height) // here we stop, one of the stop-conditional
            {
                matrix[j,i] = k;
                break;
            }

            left_steps++;

            while (j > right_steps) // left walking -> from the bottom up
            {
                matrix[j,i] = k;
                k++;
                j--;
            }

            if (j == right_steps && up_steps + down_steps + 1 == width) // here we stop, one of the stop-conditional
            {
                matrix[j,i] = k;
                break;
            }
            up_steps++;
        }
    }

    public static void SpiralOrderAlt(int[,] matrix) 
    { 
        jMax = matrix.GetLength(0);
        iMax = matrix.GetLength(1);
        ZeroFill(matrix);
        SpiralOrderRec(0, 1, 0, 0, matrix);
    }

    public static void SpiralOrderRec(int counter, int num, int j, int i, int[,] matrix)
    {
        matrix[j, i] = num; // filling

        int jD = directions[counter % 4][0]; // deltas for next step Coords
        int iD = directions[counter % 4][1];

        if (counter > 2 * Math.Min(jMax, iMax)) return; // approx stop condition    

        if (j + jD >= 0 && i + iD >= 0 && j + jD < jMax && i + iD < iMax && matrix[j + jD, i + iD] == 0) // forward branch
        {          
            SpiralOrderRec(counter, num + 1, j + jD, i + iD, matrix);
        }
        else // direction change branch
        {           
            SpiralOrderRec(counter + 1, num, j, i, matrix);
        }
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
        int length = (int) Math.Log10(maxValue) + 1;

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
