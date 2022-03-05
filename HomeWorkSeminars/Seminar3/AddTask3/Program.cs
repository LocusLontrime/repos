public class AddTask2and4 // Даны 4 точки a, b, c, d. Пересекаются ли вектора AB и CD?
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter 4 pairs of coordinates X and Y for all four points (A,B,C,D)");

        List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

        for (int i = 0; i < 4; i++) list.Add(new KeyValuePair<double, double>(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));     

        LineSegment AB = new LineSegment(list[0], list[1]);
        LineSegment CD = new LineSegment(list[2], list[3]);

        Console.WriteLine("Line segments contain the Point of intersection: " + LineSegment.ContainsPointOfIntersection(AB, CD));
    }

    public static void Quarter(KeyValuePair<double, double> point) 
    {
        if (point.Key > 0 && point.Value > 0) Console.WriteLine("Point located in I quarter");
        else if (point.Key < 0 && point.Value > 0) Console.WriteLine("Point located in II quarter");
        else if (point.Key < 0 && point.Value < 0) Console.WriteLine("Point located in III quarter");
        else if (point.Key > 0 && point.Value < 0) Console.WriteLine("Point located in IV quarter");
        else if (point.Key == 0 && point.Value == 0) Console.WriteLine("Point located in the coordinate center");
        else if (point.Key == 0) Console.WriteLine("Point located on abscissa axis");
        else Console.WriteLine("Point located on ordinate axis");
    }
}