using System.Numerics;

public class Sem2HomeTask6 // Найти расстояние между точками в пространстве 2D/3D
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Enter 2 to calculate 2D-distance and 3 for 3D-distance");
        int number = int.Parse(Console.ReadLine());

        if (number == 2)
        {
            Console.WriteLine("X1");
            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Y1");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine("X2");
            int number3 = int.Parse(Console.ReadLine());
            Console.WriteLine("Y2");
            int number4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Distance = " + distance(number1, number3, number2, number4, 0, 0));
        }
        else if (number == 3)
        {
            Console.WriteLine("X1");
            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Y1");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Z1");
            int number3 = int.Parse(Console.ReadLine());
            Console.WriteLine("X2");
            int number4 = int.Parse(Console.ReadLine());
            Console.WriteLine("Y2");
            int number5 = int.Parse(Console.ReadLine());
            Console.WriteLine("Z2");
            int number6 = int.Parse(Console.ReadLine());
            Console.WriteLine("Distance = " + distance(number1, number4, number2, number5, number3, number6));
        }
        else 
        {
            Console.WriteLine("Enter 2 or 3");
        }
        
    }
    public static double distance(int x1, int x2, int y1, int y2, int z1, int z2) 
    {
        return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
    }
}