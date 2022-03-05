public class Sem3HomeTask3 
{

    static void Main(string[] args)
    {

        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++) Console.Write(i * i * i + " ");
  
    }
}