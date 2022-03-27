using System;

public class MainClass
{
    public static void Main()
    {

        Console.WriteLine("Задача 29: Напишите программу, которая задаёт массив из 8 случайных целых чисел и выводит отсортированный по модулю массив.");
        Console.WriteLine();

        int[] array = SortArr();
    }
    public static int[] RandArr()
    {
        // Определение рандомного массива

        int[] array = new int[8];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(10);
        }

        // Вывод полученого массива

        Console.WriteLine("Вывод полученого массива");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
        return array;
    }
    public static int[] SortArr()
    {
        int[] array = RandArr();

        //Сортировка

        int temp;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }

        //Вывод результата сортировки

        Console.WriteLine("Вывод результата сортировки");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        return array;
    }
}