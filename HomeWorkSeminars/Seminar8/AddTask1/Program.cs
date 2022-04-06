public class AddTask1 //  Дан двумерный массив. Заменить в нём элементы первой строки
                      //  элементами главной диагонали. А элементы последней строки,
                      //  элементами побочной диагонали
{
    static void Main(string[] args) // The array given should be of a square type (rows = colomns)
    {
        int[,] array = new int[,] { {1, 2, 3, 4 }, { 22, 98, 35, 76}, { 0, 80, 95, 78}, { 11, 91, 77, 99} };

        PrintArray2D(array);

        array = ChangeMatrix(array);

        PrintArray2D(array);
    }
    public static int[,] ChangeMatrix(int[,] matrix) 
    {
        if (matrix.GetLength(0) != matrix.GetLength(1)) 
        {
            Console.WriteLine("The array given should be of a square type (rows = colomns)");
            return matrix; 
        }

        int[,] newArray = (int[,]) matrix.Clone();

        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            newArray[0, i] = matrix[i, i];
            newArray[matrix.GetLength(0) - 1, i] = matrix[matrix.GetLength(0) - 1 - i, i];
        }

        return newArray;
    }
    public static void PrintArray2D(int[,] array) 
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write(array[j, i] + " ");
            }

            Console.WriteLine();
        }   
    }
}