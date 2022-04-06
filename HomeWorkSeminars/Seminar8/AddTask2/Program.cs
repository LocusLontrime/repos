public class AddTask2 // Дан двумерный массив, заполненный случайными числами от -9 до 9.
                      // Подсчитать частоту вхождения каждого числа в массив, используя словарь
{
    static void Main(string[] args)
    {
        int[,] array = new int[,] { 
            { 1, 2, 3, 4, 5, 6, 77 },
            { 1, 1, 1, 5, 55, 66, 98 },
            { 1, 0, 1, 0, 0, 99, 98 }, 
            { 22, 35, 35, 66, 78, 99, 98 },
            { 11, 11, 11, 66, 56, 68, 98},
            { 1, 1, 11, 65, 54, 48, 35 }, 
            { 1, 1, 3, 35, 77, 88, 98 } 
        };

        Console.WriteLine("Frequency dictionary: \n");

        foreach (KeyValuePair<int, int> pair in CalcFreq(array)) 
        {
            Console.WriteLine($"Element {pair.Key} occurs {pair.Value} times in the array given");
        }
    }

    public static Dictionary<int, int> CalcFreq(int[,] array) 
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (freq.ContainsKey(array[j, i]))
                {
                    freq[array[j, i]]++;
                }
                else 
                {
                    freq.Add(array[j, i], 1);
                }
            }
        }

        return freq;
    }
}