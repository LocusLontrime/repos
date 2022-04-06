public class AddTask4 
{
    static void Main(string[] args)
    {
        int[,] array = SnakeFill(4, 7);
        PrintArray2D(array);

        Console.WriteLine();

        array = SnakeFillAlt(4, 7);
        PrintArray2D(array);
    }
    public static int[,] SnakeFill(int rows, int columns) 
    {
        int[,] array = new int[rows, columns];
        int count = 1;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (i % 2 == 0) array[j, i] = count++;
                else array[rows - j - 1, i] = count++;
            }
        }

        return array;
    }

    public static int[,] SnakeFillAlt(int rows, int columns) 
    {
        int[,] array = new int[rows, columns];        

        SnakeFillRec(true, 1, 0, 0, array);

        return array;
    }

    public static void SnakeFillRec(bool recFlag, int count, int j, int i, int[,] array) 
    {
        if (i == array.GetLength(1) && (j == 0 || j == array.GetLength(0) - 1)) return;

        array[j, i] = count;

        if (recFlag)
        {
            if (j < array.GetLength(0) - 1) SnakeFillRec(recFlag, count + 1, j + 1, i, array);           
            else SnakeFillRec(!recFlag, count + 1, j, i + 1, array);                     
        }
        else 
        {
            if (j > 0) SnakeFillRec(recFlag, count + 1, j - 1, i, array);            
            else SnakeFillRec(!recFlag, count + 1, j, i + 1, array);                       
        }
    }

    public static void PrintArray2D(int[,] array)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (array[j, i] != 0) Console.Write(array[j, i] + " "); 
            }

            Console.WriteLine();
        }
    }
}