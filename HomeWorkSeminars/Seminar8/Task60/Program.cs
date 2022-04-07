public class Task60 // Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
                    // Напишите программу, которая построчно выведет элементы и их индексы
{
    static void Main(string[] args)
    {
        int[,,] Array3D = GetArray3D(10, 10, 10);
    }

    public static int[,,] GetArray3D(int p, int q, int r)
    { 
        int [,,] array = new int[p, q, r];

        for (int k = 0; k < array.GetLength(0); k++)
            for (int j = 0; j < array.GetLength(1); j++)
                for (int i = 0; i < array.GetLength(2); i++)
                {
                    array[k, j, i] = k * array.GetLength(1) * array.GetLength(2) + j * array.GetLength(2) + i;
                    Console.WriteLine($"array[{k}, {j}, {i}] = {array[k, j, i]}");
                }
        return array;
    }

    public static void PrintArray3D(int[,,] array) 
    { 



    }
}