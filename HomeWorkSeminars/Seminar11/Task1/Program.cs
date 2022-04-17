public class Task1 // На вход подуются два числа n и m, такие, что n<m. Заполните массив случайными числами из промежутка [n, m]
{
    static void Main(string[] args)
    {
        int[] array = new int[98]; // array initialization

        FillTheArray(array, 1, 100); // method call

        foreach (var item in array) Console.Write(item + " "); // printing      
    }

    public static void FillTheArray(int[] array, int n, int m) // method of random array filling
    { 
        Random random = new Random();

        for (int i = 0; i < array.Length; i++) array[i] = random.Next(n, m + 1);       
    }
}