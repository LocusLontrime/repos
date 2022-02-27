public class Task5S1
{

    static void Main(string[] args)
    {

        Console.WriteLine("Enter some number");
        int num = int.Parse(Console.ReadLine());
        if (num >= 100 && num < 1000)
        {
            Console.WriteLine(num % 10);            
        }
        else
        {
            Console.WriteLine("Enter a number with three digits");
        }


    }

}