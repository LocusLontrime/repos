public class AddTask1 // Двумерная матрица заполнена натуральными числами. Найти тройку чисел,
                      // для которых площадь треугольника со сторонами, определяемыми данной тройкой, будет максимальна
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[,] { 
            { 3, 7, 5, 9, 1 }, 
            { 1, 5, 10, 2, 3 },
            { 1, 1, 2, 7, 6 }, 
            { 1, 5, 4, 4, 3 }, 
            { 3, 6, 6, 6, 8 } 
        };

        int[] array = MaxAreaGeron(matrix);

        Console.WriteLine(array[0] + " " + array[1] + " " + array[2]);
    }

    public static int[] MaxAreaGeron(int[,] matrix) 
    {
        int[] result = new int[] { -1, -1, -1};

        int maxAreaVal = int.MinValue;

        List<int> list = new List<int>();

        for (int j = 0; j < matrix.GetLength(0); j++) // here we are adding the matrix's elements to a list for convenience
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                list.Add(matrix[j, i]);
            }
        }

        for (int j = 0; j < list.Count; j++) // now we bruteforcing through the all elements and finding the sides of the max area triangle if sucj exists
        {
            for (int i = j + 1; i < list.Count; i++)
            {
                for (int l = i + 1; l < list.Count; l++) 
                {
                    if (IsTriangle(list[j], list[i], list[l]))
                    {

                        int semiPerimeter2X = list[j] + list[i] + list[l];
                        int currVal = semiPerimeter2X * (semiPerimeter2X - 2 * list[j]) * (semiPerimeter2X - 2 * list[i]) * (semiPerimeter2X - 2 * list[l]);

                        if (maxAreaVal < currVal)
                        {
                            maxAreaVal = currVal;

                            result[0] = list[j];
                            result[1] = list[i];
                            result[2] = list[l];
                        }
                    }
                }
            }
        }

        return result;
    }

    public static bool IsTriangle(int a, int b, int c) => (a < b + c && b < a + c && c < a + b);

}
