public class MaxSubmatrixSumTask //Пусть дана матрица размером N*N, содержащая положительные и отрицательные числа.
                                 // Напишите код поиска субматрицы с максимально возможной суммой.
{
    public static int jMax, iMax;    

    static void Main(string[] args)
    {
        int[,] matrix = new int[,] {
            { 11, -77, 88, 98, -12, -44, -101 }, 
            { -54, 12, 0, 1, -1, 17, -98 },
            { -11, -12, -44, 35, 36, 99, 101},
            { 55, 56, -77, -88, -12, 1, 0 }, 
            { 0, 0, 1, 11, -55, -66, 7},
            { 101, 1, 12, -9, -67, -88, 100 }, 
            {11, 12, 56, 54, 78, -101, -99 } 
        };

        Console.WriteLine(MaxSubmatrixSum(matrix));
    }

    public static int[,] GetPreSumMatrix(int[,] matrix) 
    {
        int[,] preSumMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

        for (int j = 0; j < jMax; j++)
        {
            for (int i = 0; i < iMax; i++)
            {
                if (i == 0 && j == 0) preSumMatrix[j, i] = matrix[j, i];
                else if (j == 0) preSumMatrix[j, i] = preSumMatrix[j, i - 1] + matrix[j, i];              
                else if (i == 0) preSumMatrix[j, i] = preSumMatrix[j - 1, i] + matrix[j, i];
                else preSumMatrix[j, i] = preSumMatrix[j, i - 1] + preSumMatrix[j - 1, i] - preSumMatrix[j - 1, i - 1] + matrix[j, i];
            }
        }

        return preSumMatrix;
    }

    public static int MaxSubmatrixSum(int[,] matrix) // PreSums method, runtime: O((m * n) ^ 2)
    { 
        jMax = matrix.GetLength(0);
        iMax = matrix.GetLength(1);

        int[,] preSumMatrix = GetPreSumMatrix(matrix);

        int maxSum = int.MinValue;
        int currSum;

        int[,] subMatrixCoords = new int[2, 2];

        for (int j = 0; j < jMax; j++)
        {
            for (int i = 0; i < iMax; i++)
            {
                for (int jDelta = 0; j + jDelta < jMax; jDelta++)
                {
                    for (int iDelta = 0; i + iDelta < iMax; iDelta++)
                    {
                        if (j == 0 && i == 0) currSum = preSumMatrix[j + jDelta, i + iDelta];
                        else if (j == 0) currSum = preSumMatrix[j + jDelta, i + iDelta] - preSumMatrix[j + jDelta, i - 1];
                        else if (i == 0) currSum = preSumMatrix[j + jDelta, i + iDelta] - preSumMatrix[j - 1, i + iDelta];
                        else currSum = preSumMatrix[j + jDelta, i + iDelta] - preSumMatrix[j - 1, i + iDelta] - preSumMatrix[j + jDelta, i - 1] + preSumMatrix[j - 1, i - 1];

                        if (maxSum < currSum)
                        { 
                            maxSum = currSum;

                            subMatrixCoords[0, 0] = j;
                            subMatrixCoords[0, 1] = i;

                            subMatrixCoords[1, 0] = j + jDelta;
                            subMatrixCoords[1, 1] = i + iDelta;
                        }
                    }
                }
            }
        }

        Console.WriteLine($"Largest Sum SubMatrix coords: ({subMatrixCoords[0, 0]}, {subMatrixCoords[0, 1]}) -> ({subMatrixCoords[1, 0]}, {subMatrixCoords[1, 1]})");

        return maxSum;
    }
}