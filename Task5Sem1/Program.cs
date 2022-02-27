public class Task5Sem1 {

    static void Main(string[] args)
    {

        Console.WriteLine("Enter some number");
        string s = Console.ReadLine();
        if (s.Length == 3)
        {
            try
            {               
                Console.WriteLine(int.Parse(s) % 10);
            }
            catch (Exception) {
                Console.WriteLine("Your input is out of range");
            }

        }
        else 
        {
            Console.WriteLine("Enter a number with three digits");
        }
        

    }

}
