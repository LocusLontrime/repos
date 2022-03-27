using LibZett;

public class ArrayAnalizator // Определить какая сумма элементов массива больше, с четными индексами или с нечетными
{

    static void Main(string[] args)
    {
        int[] array = new int[] { 4, 5, 89, 98, 3, 66, 98 };

        array = Library.GetRandomArray1D(98);

        Analize(array);
    }

    public static void Analize(int[] array)    
    {
        int oddSum = 0, evenSum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0) // even indexes
            {
                evenSum += array[i];
            }
            else // odd indexes
            { 
                oddSum += array[i];
            }
        }

        if (oddSum == evenSum) Console.WriteLine("Sums are equal");
        else if (oddSum > evenSum) Console.WriteLine("Odd Sum is larger");
        else Console.WriteLine("Even Sum is larger");
    }
}