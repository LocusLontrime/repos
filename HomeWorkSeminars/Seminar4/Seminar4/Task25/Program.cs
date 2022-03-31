public class Task25 // Напишите цикл, который принимает на вход два натуральных числа
                    // (A и B) и возводит число A в степень B.
{
    static void Main(string[] args)
    {
        Console.WriteLine(Pow(5, 3));

        Console.WriteLine(Pow(0, 0));
    }

    public static int Pow(int baseNumber, int power) 
    {
        if (baseNumber <= 0 || power <= 0) 
        {
            Console.WriteLine("Both numbers should be Natural");
            return 0;
        }

        int result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= baseNumber;
        }

        return result;
    }
}