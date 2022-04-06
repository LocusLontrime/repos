public class AddTask1 
{
    static void Main(string[] args)
    {
        int[,] array1 = new int[,] { { 3, 4 }, { 5, 6 }, { 7, 8 } };
        int[,] array2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6} };

        Matrix m1 = new Matrix(array1);
        Matrix m2 = new Matrix(array2);

        Matrix m3 = m1.MultiplyRight(m2);

        m3.Print();

        Console.WriteLine();

        Matrix matrix1 = new Matrix(3, 4);
        Matrix matrix2 = new Matrix(4, 3);

        matrix1.RandomFill(-9, 9);
        matrix2.RandomFill(-9, 9);

        Matrix matrix3 = matrix1.MultiplyRight(matrix2);

        matrix3.Print();
    }

    public class Matrix 
    { 
        public int[,] matrix;

        public Matrix(int rows, int columns)
        { 
            matrix = new int[rows, columns];
        }

        public Matrix(int[,] array)
        { 
            matrix = array;
        }

        public int GetRows() 
        { 
            return matrix.GetLength(0);
        }

        public int GetColumns()
        {
            return matrix.GetLength(1);
        }

        public Matrix MultiplyRight(Matrix matrix)
        {

            if (this.GetColumns() != matrix.GetRows())
            {
                Console.WriteLine("Multiplication is not allowed!");
                throw new ArithmeticException("Rows number of the left matrix does not equal the columns number of the right one");
            }

            Matrix multipliedMatrix = new Matrix(this.GetRows(), matrix.GetColumns());

            for (int i = 0; i < multipliedMatrix.GetRows(); i++)
            {
                for (int j = 0; j < multipliedMatrix.GetColumns(); j++)
                {
                    multipliedMatrix.matrix[i, j] = 0;

                    for (int n = 0; n < this.GetColumns(); n++)
                    {
                        multipliedMatrix.matrix[i, j] += this.matrix[i, n] * matrix.matrix[n, j];
                    }
                }
            }

            return multipliedMatrix;
        }

        public void RandomFill(int min, int max)
        {
            int[,] array = this.matrix;

            Random r = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    this.matrix[i, j] = r.Next(min, max + 1);
                }
            }
        }

        public void Print () // enhanced printing method, it prints the array in a more convenient way
        { // auxiliary method for 2D array printing
            int[,] array = this.matrix;

            int maxValue = this.GetMaxAbs();
            int length = (int)Math.Log10(maxValue) + 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int currentNumberLength = (int) Math.Log10(Math.Abs(array[i, j])) + 1;
                    Console.Write(array[i, j]);
                    for (int k = 0; k <= length - currentNumberLength; k++) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public int GetMaxAbs()
        {
            int[,] array = this.matrix;

            int max = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    max = Math.Max(Math.Abs(max), Math.Abs(array[i, j]));
                }
            }

            return max;
        }
    }
}