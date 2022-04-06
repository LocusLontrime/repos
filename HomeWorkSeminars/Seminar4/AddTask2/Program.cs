public class AddTask2 // Напишите метод, который заполняет массив случайным количеством (от 1 до 100)
                      // нулей и единиц. Размер массива должен совпадать с квадратом количества единиц в нём
{
    static void Main(string[] args)
    {
        int[] array = StrangeFill();
        PrintArray1D(array);
    }
    public static int[] StrangeFill()
    { 
        Random random = new Random();
        int index;
        int onesQuantity = random.Next(1, 11);
        int[] array = new int[onesQuantity * onesQuantity];
        List<int> list = new List<int>();

        Console.WriteLine("Ones quantity: " + onesQuantity + ", array Length: " + onesQuantity * onesQuantity + " \n");

        for (int i = 0; i < onesQuantity; i++) // random positions of all 1s
        {
            while (true)
            {
                index = random.Next(0, onesQuantity * onesQuantity);
                if (!list.Contains(index)) break;
            }

            array[index] = 1;
            list.Add(index);
        }

        for (int i = 0; i < onesQuantity * onesQuantity; i++) // other places in the array are being filled with 0s
        { 
            if (array[i] != 1) array[i] = 0;
        }

        return array;
    }
    public static void PrintArray1D(int[] array) // just printing
    {
        // easy peasy, keep Smitty!
        for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " ");
    }
}
