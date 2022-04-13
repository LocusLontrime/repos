using static AddTask2;

public class AddTask2 // Дана последовательность натуральных чисел. Определите значение второго по величине элемента в этой последовательности
{
    static void Main(string[] args)
    {
        List<int> list = new List<int> { 11, 22, 32, 98, 77, 55, 99};

        Console.WriteLine(FindTheSecondMax(list)); // a merry way
    }

    public static int FindTheSecondMax(List<int> list) => list.OrderByDescending(a => a, new YourCustomClassComparer()).ElementAt(1);
    
    public class YourCustomClassComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);      
    }
}
