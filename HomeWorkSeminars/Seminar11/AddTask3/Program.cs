public class AddTask3 // Дан отсортированный по возрастанию двумерный массив Matrix.На вход подаётся число A.
                      // Напишите метод, реализующий поиск в массиве элементов, равных A.
                      // Выведите координаты элемента (при выводе нумерация строк и столбцов считается с единицы)
{
    public static int searchCounter;

    static void Main(string[] args)
    {
        int [,] matrix = new int[,] {
            {3, 5, 11, 17, 23}, 
            {36, 55, 83, 85, 95},
            {101, 102, 111, 203, 245}
        };

        matrix = RandomArray2D(10000, 10000, 10);

        Console.WriteLine("Max element of matrix: " + matrix[9999, 9999] + "\n");

        CoordsSearch(matrix, 99999999);

        // int[] array = new int[] { 1, 2, 4, 5, 11, 15, 16, 17, 22, 23, 35, 48, 54, 78, 91, 94, 96, 97, 98, 99};

        // Console.WriteLine(SpecialBinSearch(array, 95));

        MatrixBinSearch(matrix, 99999999);
    }

    public static void CoordsSearch(int[,] matrix, int element) // O(n + m) runtime, not optimized, there is a method with O(log(max(n,m))) runtime
                                                                // using the binary search (at first in a column -> then in a row)
    {
        searchCounter = 0;

        if (element < matrix[0, 0] ||
            element > matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]) // checks if the element is situated between the border values
        {
            Console.WriteLine("The element is not found in the matrix given");
            Console.WriteLine($"{searchCounter} steps has been made");
            return;
        }

        int jEl = -1;

        for (int j = 0; j < matrix.GetLength(0); j++) // defines the row
        {
            searchCounter++;
            if (matrix[j, 0] <= element) jEl++;
            else break;
        }

        for (int i = 0; i < matrix.GetLength(1); i++) // defines the column or concludes that the element is not located in the matrix given
        {
            searchCounter++;
            if (matrix[jEl, i] == element)
            {
                Console.WriteLine($"Element coords: ({jEl}, {i})");
                break;
            }
            else if (matrix[jEl, i] > element || i == matrix.GetLength(0) - 1)
            {
                Console.WriteLine("The element is not found in the matrix given");
                break;
            }
        }

        Console.WriteLine($"{searchCounter} steps has been made");
    }

    // the fastest one
    public static void MatrixBinSearch(int[,] matrix, int element)
    {
        searchCounter = 0;

        int j = RecBinVertical(matrix, 0, matrix.GetLength(0) - 1, element); // here we're finding the row

        if (j < 0) 
        {
            Console.WriteLine("The element does not exist in the matrix given");
            Console.WriteLine($"{searchCounter} steps has been made");
            return;
        }

        int i = RecBinHorizontal(matrix, 0, matrix.GetLength(1) - 1, j, element); // here we're searching for the element in the current row

        if (i < 0) {
            Console.WriteLine("The element does not exist in the matrix given");
            Console.WriteLine($"{searchCounter} steps has been made");
            return;
        }

        Console.WriteLine($"element coords: ({j}, {i})"); // printing the element's coords

        Console.WriteLine($"{searchCounter} steps has been made");
    }

    // the Rec Method covering 
    public static int SpecialBinSearch(int[] array, int target) => RecBin(array, 0, array.Length - 1, target); // here the recursion starts    

    // the core of bin search for an 1D array (just an example to test and tune the algo)
    public static int RecBin(int[] array, int j, int i, int target) // we are searching for the index of the target in the array given
    {
        if (j == i)
        {          
             if (target == array[j]) return j;
             else return j - 1; 
        }

        int pivotIndex = (j + i) / 2;

        if (target == array[j]) return j; 
        else if (target > array[pivotIndex])  return RecBin(array, pivotIndex + 1, i, target); 
        else return RecBin(array, j, pivotIndex, target);             
    }

    // bin search through the matrix's rows
    public static int RecBinVertical(int[,] matrix, int jStart, int jEnd, int target) // we are searching for the index of the target in the first column
                                                                              // of the matrix given
    {
        searchCounter++;

        if (jStart == jEnd)
        {
            if (target == matrix[jStart, 0]) return jStart;
            else return jStart - 1;
        }

        int pivotIndex = (jStart + jEnd) / 2;

        if (target == matrix[jStart, 0]) return jStart; 
        else if (target > matrix[pivotIndex, 0]) return RecBinVertical(matrix, pivotIndex + 1, jEnd, target);
        else return RecBinVertical(matrix, jStart, pivotIndex, target);
    }

    // bin search in the chosen matrix row
    public static int RecBinHorizontal(int[,] matrix, int iLeft, int iRight, int row, int target) // we are searching for the index of the target
                                                                                         // in the current row of the matrix given
    {
        searchCounter++;

        if (iLeft == iRight)
        {
            if (target == matrix[row, iLeft]) return iLeft; 
            else return - 1;
        }

        int pivotIndex = (iLeft + iRight) / 2;

        if (target == matrix[row, iLeft]) return iLeft; 
        else if (target > matrix[row, pivotIndex]) return RecBinHorizontal(matrix, pivotIndex + 1, iRight, row, target);
        else return RecBinHorizontal(matrix, iLeft, pivotIndex, row, target);
    }

    public static int[,] RandomArray2D(int height, int width, int step)
    {
        int[,] matrix = new int[height, width];

        int value = 0;

        Random r = new Random();

        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {
                int delta = r.Next(step);
                matrix[j, i] = r.Next(value, value + delta);
                value += delta;
            }
        }

        return matrix;
    }
}