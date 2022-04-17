public class AddTask3 // Дан отсортированный по возрастанию двумерный массив Matrix.На вход подаётся число A.
                      // Напишите метод, реализующий поиск в массиве элементов, равных A.
                      // Выведите координаты элемента (при выводе нумерация строк и столбцов считается с единицы)
{
    static void Main(string[] args)
    {
        int [,] matrix = new int[,] {
            {3, 5, 11, 17, 23}, 
            {36, 55, 83, 85, 95},
            {101, 102, 111, 203, 245}
        };

        CoordsSearch(matrix, 98);
    }

    public static void CoordsSearch(int[,] matrix, int element) // O(n + m) runtime, not optimized, there is a method with O(log(max(n,m))) runtime
                                                                // using the binary search (at first in a column -> then in a row)
    {
        if (element < matrix[0, 0] ||
            element > matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]) // checks if the element is situated between the border values
        {
            Console.WriteLine("The element is not found in the matrix given");
            return;
        }

        int jEl = -1;

        for (int j = 0; j < matrix.GetLength(0); j++) // defines the row
        {
            if (matrix[j, 0] <= element) jEl++;
            else break;
        }

        for (int i = 0; i < matrix.GetLength(1); i++) // defines the column or concludes that the element is not located in the matrix given
        {
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
    }
}