public class AddTaskStar // Дан массив массивов, состоящих из натуральных чисел,
                         // размер которого 5. Для каждого элемента-массива.
                         // Найти сумму его элементов и вывести массив с наибольшей суммой.
                         // Если таких массивов несколько, вывести массив с наименьшим индексом
{

    static void Main(string[] args)
    {
        int[][] arrayOfArrays = new int[5][];

        arrayOfArrays[0] = new int[] { 1, 2, 3 };
        arrayOfArrays[1] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        arrayOfArrays[2] = new int[] { 900, 1, 88 };
        arrayOfArrays[3] = new int[] { 98, 99 };
        arrayOfArrays[4] = new int[] { 989 };

        int[] result = GetMaxSumArray1D(arrayOfArrays);

        foreach (var item in result) 
        {
            Console.Write(item + " ");
        }
    }

    public static int[] GetMaxSumArray1D(int[][] arrayOfArrays) 
    {
        int maxSum = int.MinValue;
        int sum;

        int[] result = new int[0];

        for (int j = 0; j < arrayOfArrays.Length; j++)
        {
            sum = 0;

            for (int i = 0; i < arrayOfArrays[j].Length; i++)
            {
                sum += arrayOfArrays[j][i];
            }

            if (sum > maxSum) 
            {
                maxSum = sum;
                result = arrayOfArrays[j];
            }
        }

        Console.WriteLine("Max sum = " + maxSum);

        return result;
    }
}