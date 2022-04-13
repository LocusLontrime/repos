public class Task2 // Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями
                   // y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем
{
    static void Main(string[] args)
    {
        double[] point = PointOfIntersection(1, 3, 11, 16);
        Console.WriteLine(point[0] + " " + point[1]);

        point = PointOfIntersection(1, 3, 1, 7);
        Console.WriteLine(point[0] + " " + point[1]);
    }

    public static double[] PointOfIntersection(int k1, int b1, int k2, int b2) 
    {
        double[] point = new double[2];

        if (k1 == k2 && b1 == b2)
        {
            Console.WriteLine("The straight lines are the same");
            return null;
        }
        else if (k1 == k2)
        {
            Console.WriteLine("The straight lines are parallel");
            return null;
        }
        else 
        { 
            point[0] = 1.0 * (b1 - b2) / (k2 - k1);
            point[1] = k1 * point[0] + b1;
        }

        return point;
    }
}