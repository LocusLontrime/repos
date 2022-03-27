namespace LibZett
{
    public class Library
    {
        static void Main(string[] args)
        {

        }
        public static int[] GetRandomArray1D(int length) // creates a 1D-array of Integers of length = length
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, length + 1);
            }

            return array;
        }

        public static int[,] GetRandomArray2D(int heigth, int width) // creates a 2D-array of Integers of height and width
        {
            Random random = new Random();
            int[,] array = new int[heigth, width];

            for (int i = 0; i < heigth; i++) // номер строки
            {
                for (int j = 0; j < width; j++) // номер столбца
                {
                    array[i, j] = random.Next(0, 100 *heigth * width + 1);
                }
            }

            return array;
        }

        public static void PrintArray1D(int[] array) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        public static void PrintArray2D(int[,] array) 
        {
            for (int i = 0; i < array.GetLength(0); i++) // номер строки
            {
                for (int j = 0; j < array.GetLength(1); j++) // номер столбца
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }    
    }
}