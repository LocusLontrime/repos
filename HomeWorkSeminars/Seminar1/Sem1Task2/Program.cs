namespace Sem1Task2 // найти максимум из трёх чисел
{
    public class Sem1Task2
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Enter three numbers, each of them on a new line");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine("max number = " + max(max(num1, num2), num3)); // method using
        }

        public static int max(int a, int b) // finds the maximum of two numbers given
        { 
            return a > b ? a : b; // ternary operator
        }
    }
}