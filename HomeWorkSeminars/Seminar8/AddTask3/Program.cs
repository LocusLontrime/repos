public class AddTask3 // Найти минимальный по модулю элемент. Удалить столбец и диагонали, содержащие его
{
    public static int jStart, iStart;

    static void Main(string[] args)
    {
        int[,] matrix = new int[,] { // just an example for testing
            { 91, 22, 33, 44, 88, 25, 99 },
            { 81, 44, 66, 99, 97, 85, 99 },
            { 22, 90, 98, 89, 17, 56, 79 }, 
            { 74, 82, 88, 95, 98, 87, 96 },
            { 77, 66, 51, 35, 36, 78, 92 }, 
            { 67, 24, 53, 68, 69, 90, 84}, 
            { 27, 44, 57, 75, 76, 83, 99 } 
        };

        DeleteRowAndDiagons(matrix); // method call

        PrintArray2D(matrix); // printing the result
    }

    public static void DeleteRowAndDiagons(int[,] matrix) 
    {
        int jS = 0, iS = 0;   

        int min = int.MaxValue;

        //fings the min element in terms of Math.Abs
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[j, i] < min) 
                {
                    jS = j;
                    iS = i;

                    min = matrix[j, i];
                }
            }
        }

        jStart = jS;
        iStart = iS;

        Console.WriteLine("Min in terms of Math.Abs element coords -> jS = " + jS + " iS = " + iS + "\n");
        
        RecDel(jS, iS, matrix);
    }

    public static void RecDel(int j, int i, int[,] matrix) // a strange recursion 
    {
        if (!(i >= 0 && j >= 0 && j < matrix.GetLength(0) && i < matrix.GetLength(1))) return;

        matrix[j, i] = 0; // nullification
    
        if ((j == jStart && i == iStart) || j < jStart && i < iStart) RecDel(j - 1, i - 1, matrix);
        if ((j == jStart && i == iStart) || j < jStart && i > iStart) RecDel(j - 1, i + 1, matrix);
        if ((j == jStart && i == iStart) || j > jStart && i < iStart) RecDel(j + 1, i - 1, matrix);
        if ((j == jStart && i == iStart) || j > jStart && i > iStart) RecDel(j + 1, i + 1, matrix);
        if ((j == jStart && i == iStart) || j < jStart && i == iStart) RecDel(j - 1, i, matrix);
        if ((j == jStart && i == iStart) || j > jStart && i == iStart) RecDel(j + 1, i, matrix);
        // if ((j == jStart && i == iStart) || j == jStart && i < iStart) RecDel(j, i - 1, matrix); // for row
        // if ((j == jStart && i == iStart) || j == jStart && i > iStart) RecDel(j, i + 1, matrix);
    }

    public static void PrintArray2D(int[,] array)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (array[j, i] != 0) Console.Write(array[j, i] + " ");
                else Console.Write(array[j, i] + "  ");
            }

            Console.WriteLine();
        }
    }

}