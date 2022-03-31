public class Task29 // Напишите программу, которая задаёт массив из 8 случайных целых чисел
                    // и выводит отсортированный по модулю массив
{
    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 11, -69, 118, 9, -278, 0, 8, -36, 0, 98989 };
        BubbleModSort(array);
        PrintArray1D(array);
    }

    public static void BubbleModSort(int[] array) // Rabotkin mode
    {
        int length = array.Length;

        int temp;

        for (int i = length - 1; i > 0; i--) // количество всплытий
        {
            for (int j = 0; j < i; j++) // процедура всплытия пузырька
            {
                if (Math.Abs(array[j]) > Math.Abs(array[j + 1]))
                {
                    temp = array[j]; // element swapping
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                } 
            }
        }
    }

    public static void PrintArray1D(int[] array) 
    {
        // easy peasy, keep Smitty!
        for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " ");
    }
}