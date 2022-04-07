public class Task60 // Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
                    // Напишите программу, которая построчно выведет элементы и их индексы
{
    static void Main(string[] args)
    {
        int[,,] Array3D = GetArray3D(100, 100, 100);
    }

    public static int[,,] GetArray3D(int p, int q, int r)
    { 
        int [,,] array = new int[p, q, r];

        for (int k = 0; k < array.GetLength(0); k++)
            for (int j = 0; j < array.GetLength(1); j++)
                for (int i = 0; i < array.GetLength(2); i++)
                {
                    array[k, j, i] = k * array.GetLength(1) * array.GetLength(2) + j * array.GetLength(2) + i; // filling
                    Console.WriteLine($"array[{k}, {j}, {i}] = {array[k, j, i]}"); // printing
                }
        return array;
    }

    public static void PrintArray3D(int[,,] array) // for no purpose this one built 
    { 

    }
}