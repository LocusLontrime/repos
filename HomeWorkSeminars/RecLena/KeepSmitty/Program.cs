public class RabotkinProject // Вывести в строку через пробел все цифры числа друг за другом
{

    static void Main(string[] args)
    {
        int number = 198567366;

        PrintDigitsRec(number);
    }

    public static void PrintDigitsRec (int number) 
    {
        // border case
        if (number == 0) return; // end of recursion              

        // recurrent relation or recursive call
        PrintDigitsRec (number / 10);

        // do phase way back
        Console.Write(number % 10 + " ");
    }
}