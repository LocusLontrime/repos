public class AddTask8 //Массив из ста элементов заполняется случайными числами от 1 до 100.
                      //Удалить из массива все элементы, содержащие число 3.
                      //Вывести в консоль новый массив и количество удалённых элементов
{
    public static void Main(string[] args)
    {      
        int[] array = new int[] { 1, 11, 23, 33, 98, 66, 63, 36, 96, 100, 100, 1, 98, 93, 33, 97, 96};
        Console.Write("Old array: ");
        foreach (int i in array) Console.Write(i + " ");
        // Console.WriteLine();
        Console.Write("\n" + "New array: ");
        List<int> list = DeleteAllNumbersContaining3(array); // method call
        foreach (int i in list) Console.Write(i + " ");
    }

    public static List<int> DeleteAllNumbersContaining3(int[] array) // returns a list based on initial array without elements containing digit "3"
    {
        List<int> list = new List<int>();
        foreach (int i in array) if (!Contains3(i)) list.Add(i);     
        return list;
    }

    public static bool Contains3(int num) // checks if the num contains digit "3"
    {       
        int digit;

        while (num > 0) // cycling all over the digits
        { 
            digit = num % 10;
            if (digit == 3) return true;
            num /= 10;
        }

        return false;
    }
}