public class StartingProject 
{

    static void Main(string[] args)
    {

        Console.WriteLine("Enter a 3-digit number: ");
        int num = int.Parse(Console.ReadLine());

        num = num / 10;

        Console.WriteLine(num % 10);
    }
}