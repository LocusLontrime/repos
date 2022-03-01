public class Sem2HomeTask1 { // Показать числа от -N до N

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int i = -number;

        while (i <= number) Console.Write(i++ + " ");
    }

}