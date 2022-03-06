public class SpiralMatrix {

    public static void Main(String[] args) {

        int[,] array = new int[45, 45];

        print_2D_array(array);

        Console.WriteLine();

        spiralOrder(array);

        print_2D_array (array);

    }

    public static void spiralOrder(int[,] matrix) // fulfilling the matrix with the numbers in spiral order
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
