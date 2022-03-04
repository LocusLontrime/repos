using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class LineSegment
{
    public KeyValuePair<double, double> startPoint { get; set; } // ??? gettrs and setters accessability
    public KeyValuePair<double, double> endPoint { get; set; }

    public LineSegment() 
    { 
    }

    public LineSegment(KeyValuePair<double, double> startPoint, KeyValuePair<double, double> endPoint) 
    { 
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }

    public bool containsPoint(KeyValuePair<double, double> point) => new StraightLine(this).containsPoint(point) && 
        Math.Min(startPoint.Key, endPoint.Key) <= point.Key && point.Key <= Math.Max(startPoint.Key, endPoint.Key);
    public static bool containcPointOfIntersection(LineSegment segment1, LineSegment segment2) 
    {
        StraightLine ABline = new StraightLine(segment1);
        StraightLine CDline = new StraightLine(segment2);

        Console.WriteLine("AB straight line equasion: " + ABline.angleCoefficient + "*x " + (ABline.shift > 0 ? "+ " : "- ") + Math.Abs(ABline.shift));
        Console.WriteLine("CD straight line equasion: " + CDline.angleCoefficient + "*x " + (ABline.shift > 0 ? "+ " : "- ") + Math.Abs(CDline.shift));

        if (StraightLine.isParallel(ABline, CDline))
        {
            Console.WriteLine("As the line AB is Parallel to the line CD -> the point of intercection does not exist in the context of the task given");
            return false; 
        }
      
        KeyValuePair<double, double> pointOfIntersection = StraightLine.PointOfIntercection(ABline, CDline);

        Console.WriteLine("Point of intercection coordinates: (" +
            pointOfIntersection.Key + "," + pointOfIntersection.Value + ")");

        return segment1.containsPoint(pointOfIntersection) && segment2.containsPoint(pointOfIntersection);
    }
}

