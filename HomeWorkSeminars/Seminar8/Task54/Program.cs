using System.Collections.Generic;
using System.Linq;

public class Task54 // Задайте двумерный массив. Напишите программу,
                    // которая упорядочит по убыванию элементы каждой строки двумерного массива
{
    static void Main(string[] args)
    {
        int[,] array2D = new int[5, 7] { 
            { 76, 33, 22, 66, 55, 77, 99 },
            { 25, 65, 76, 87, 45, 98, 97 }, 
            { 10, 24, 35, 36, 76, 85, 92 }, 
            { 45, 98, 77, 65, 43, 12, 90}, 
            { 94, 93, 67, 78, 87, 88, 96 }
        };

        Sort2D(array2D);

        PrintArray2D(array2D); // just printing
    }

    public static void Sort2D(int[,] array) 
    {     
        RecBubble2D(0, array.GetLength(1) - 1, 0, array); // first recursion call    
    }

    public static void RecBubble2D(int i, int j, int row, int[,] array) // just a rec bubble 2 dims
    {
        if (row == array.GetLength(0)) return; // base case
        if (j == 1) RecBubble2D(0, array.GetLength(1) - 1, row + 1, array); 
        else if (i + 1 < j) 
        {
            Swap(i, row, array);
            RecBubble2D(i + 1, j, row, array);
        }
        else RecBubble2D(0, j - 1, row, array);     
    }

    public static void Swap(int i, int row, int[,] array) 
    {
        int temp;

        if (array[row, i] > array[row, i + 1])
        {
            temp = array[row, i];
            array[row, i] = array[row, i + 1];
            array[row, i + 1] = temp;
        }
    }

    public static void PrintArray2D(int[,] array)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (array[j, i] != 0) Console.Write(array[j, i] + " ");
            }

            Console.WriteLine();
        }
    }
}