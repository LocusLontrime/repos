public class Task21 // Напишите программу, которая принимает на вход
                    // координаты двух точек и находит расстояние между ними
                    // в 3D пространстве
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter three coordinates of point 1 and after that " +
            "3 coordinates of point 2");

        int x1 = int.Parse(Console.ReadLine()); // first point
        int y1 = int.Parse(Console.ReadLine());
        int z1 = int.Parse(Console.ReadLine());

        int x2 = int.Parse(Console.ReadLine()); // second one
        int y2 = int.Parse(Console.ReadLine());
        int z2 = int.Parse(Console.ReadLine());

        double distance = Math.Sqrt((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1) 
            + (z2 - z1) * (z2 - z1));

        Console.WriteLine("The distance between two point given is equal to: " + distance);
    }
}