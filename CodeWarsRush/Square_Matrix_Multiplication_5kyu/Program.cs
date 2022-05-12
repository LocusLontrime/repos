public class SquareMatrixMultiplication {
    static void Main(string[] args)
    {
        int[,] a = { { 1, 2, 3 }, { 3, 2, 1 }, { 2, 1, 3 } };
        int[,] b = { { 4, 5, 6 }, { 6, 5, 4 }, { 4, 6, 5 } };

        PrintMatrix(MatrixMultiplication(a, b));
    }

    public static int[,] MatrixMultiplication(int[,] a, int[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0))
        {
            Console.WriteLine("Multiplication is not allowed!");
            throw new ArithmeticException("Rows number of the left matrix does not equal the columns number of the right one");
        }

        int[,] multipliedMatrix = new int[a.GetLength(0), b.GetLength(1)];

        for (int i = 0; i < multipliedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < multipliedMatrix.GetLength(1); j++)
            {
                multipliedMatrix[i, j] = 0;

                for (int n = 0; n < a.GetLength(1); n++)
                {
                    multipliedMatrix[i, j] += a[i, n] * b[n, j];
                }
            }
        }

        return multipliedMatrix;
    }

    public static void PrintMatrix(int[,] a)
    {
        for (int j = 0; j < a.GetLength(0); j++)
        {
            for (int i = 0; i < a.GetLength(1); i++)
            {
                Console.Write(a[j, i] + " "); ;
            }

            Console.WriteLine();
        }
    }
}