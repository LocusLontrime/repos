public class MatrixDeterminant // accepted on codewars.com
{
    public static int calls;

    static void Main(string[] args)
    {

        int[,] matrix = new int[,] 
        {
            { 2, 5, 3 },
            { 1,-2,-1 },
            { 1, 3, 4 }
        };

        int[,] minor = Minor1I(1, matrix);       

        calls = 0;

        Console.WriteLine($"Det = {Det(matrix)}, calls = {calls}");
    }

    public static int Det(int[,] matrix)
    { // recurrent method for calculating the determinant of the basic Matrix
        calls++;

        int det = 0;       
        
        if (matrix.GetLength(0) == 2)
        {
            det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];                        
        }
        else
        {  // factorization
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i % 2 == 0) det = det + Det(Minor1I(i + 1, matrix)) * matrix[0, i];
                else det = det - Det(Minor1I(i + 1, matrix)) * matrix[0, i];
            }
        }

        return det;
    }

    public static int[,] Minor1I(int column, int[,] matrix)
    {

        int[,] minor = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j < column - 1) minor[i - 1, j] = matrix[i, j];
                if (j > column - 1) minor[i - 1, j - 1] = matrix[i, j];
            }
        }

        return minor;
    }
}