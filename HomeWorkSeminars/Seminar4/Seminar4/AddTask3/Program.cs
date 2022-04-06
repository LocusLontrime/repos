public class AddTask3 // Массив на 100 элементов задаётся случайными числами от 1 до 99.
                      // Определите самый часто встречающийся элемент в массиве.
                      // Если таких элементов несколько, вывести их все
{
    public static Dictionary<int, int> freqDict;
    static void Main(string[] args)
    {
        GetRandomFilledArray();   
    }

    public static void GetRandomFilledArray()
    {
        int[] array = new int[100];

        Random random = new Random();
        freqDict = new Dictionary<int, int>();

        for (int i = 0; i < array.Length; i++) // random array filling and building dictionary simultaniously
        { 
            array[i] = random.Next(0, 100);

            if (freqDict.ContainsKey(array[i]))
            {
                freqDict[array[i]]++;
            }
            else 
            {
                freqDict.Add(array[i], 1);
            }
        }

        PrintArray1D(array);     

        int maxValue = freqDict.Max(v => v.Value);
        Console.Write("\nMost freq elements: ");
        foreach (var item in freqDict) if (item.Value == maxValue) Console.Write(item.Key + " ");
    }

    public static void PrintArray1D(int[] array) // just printing
    {
        Console.WriteLine("Array's elements: \n"); // easy peasy, keep Smitty!
        for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " ");
    }
}