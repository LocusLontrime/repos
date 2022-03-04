public class AddTask3 // Даны 4 точки a, b, c, d. Пересекаются ли вектора AB и CD?
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter 4 pairs of coordinates X and Y for all fourts points (A,B,C,D)");

        List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

        for (int i = 0; i < 4; i++) list.Add(new KeyValuePair<double, double>(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));

        foreach (KeyValuePair<double, double> kvp in list) Console.WriteLine(kvp.Key + " " + kvp.Value);

        LineSegment AB = new LineSegment(list[0], list[1]);
        LineSegment CD = new LineSegment(list[2], list[3]);

        Console.WriteLine("Line segments contain the Point of entercection: " + LineSegment.containcPointOfIntersection(AB, CD));
    }

    public static void Quarter(KeyValuePair<double, double> point) 
    {
        if (point.Key > 0 && point.Value > 0) Console.WriteLine("Point lies in I quarter");
        else if (point.Key < 0 && point.Value > 0) Console.WriteLine("Point lies in II quarter");
        else if (point.Key < 0 && point.Value < 0) Console.WriteLine("Point lies in III quarter");
        else if (point.Key > 0 && point.Value < 0) Console.WriteLine("Point lies in IV quarter");
        else if (point.Key == 0 && point.Value == 0) Console.WriteLine("Point lies in the coordinate center");
        else if (point.Key == 0) Console.WriteLine("Point lies on abscissa axis");
        else Console.WriteLine("Point lies on ordinate axis");
    }
}