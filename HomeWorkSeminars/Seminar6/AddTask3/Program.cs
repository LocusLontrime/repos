public class AddTask3 // Дано число N. Используя рекурсию, определите, что оно является степенью числа 3
{
    static void Main(string[] args) 
    {
        Console.WriteLine(IsPowerOf3(243));
    }

    public static bool IsPowerOf3(int num) 
    { 
        if (num == 1) return true;

        return num % 3 == 0 ? IsPowerOf3(num / 3) : false;
    }
}