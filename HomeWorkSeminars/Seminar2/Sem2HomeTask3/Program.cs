public class Sem2HomeTask3 // Дано число обозначающее день недели. Выяснить является номер дня недели выходным
{ 
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number == 6 || number == 7) Console.WriteLine("It's a weekend!");
        else Console.WriteLine("Ready to work.(");
    }
}