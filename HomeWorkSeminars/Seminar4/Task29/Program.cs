public class Task25 // Задача 25: Напишите цикл, который принимает на вход
                    // два натуральных числа (A и B) и возводит число A в степень B.
{ 
    static void Main(string[] args)
    {
        Console.WriteLine(Pow(5, 3));

        Console.WriteLine(Pow(0, 0));
    }

    public static int Pow(int baseNum, int power)    
    {
        if (baseNum < 1 || power < 1) 
        {
            Console.WriteLine("baseNum and Power must be Nutural ones");
            return 0;
        }
        
        int result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= baseNum;
        }

        return result;
    }

}