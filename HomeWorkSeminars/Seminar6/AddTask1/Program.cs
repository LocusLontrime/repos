using System.Text;

public class AddTask1 // Написать перевод десятичного числа в двоичное, используя рекурсию
{
    public static StringBuilder str = new StringBuilder("");

    static void Main(string[] args)
    {
        RecBinRepresentationOfNumber(1023);

        Console.WriteLine(str.ToString().Reverse().ToArray());
    }

    public static void RecBinRepresentationOfNumber(int number) 
    {
        if (number == 0) return;

        str.Append(number % 2);

        RecBinRepresentationOfNumber(number / 2);
    }
}