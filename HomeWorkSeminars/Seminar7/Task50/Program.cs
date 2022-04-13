public class Task50 // Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
                    // и возвращает значение этого элемента или же указание, что такого элемента нет
{
    static void Main(string[] args)
    {
        int[,] array = new int[,] { { 1, 22, 98 }, { 0, 0, 5 }, { 55, 24, 989 } };

        Console.WriteLine(GetElement(1, 2, array));

        Console.WriteLine(GetElement(7, 98, array));
    }

    public static int GetElement(int j, int i, int[,] array) 
    {
        if (j >= 0 && i >= 0 && j < array.GetLength(0) && i < array.GetLength(1))
        {
            return array[j, i];
        }
        else throw new Exception("Indexes are out of bounds");
    }

}