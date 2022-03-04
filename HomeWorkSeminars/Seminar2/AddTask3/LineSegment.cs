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
        if (startPoint.Key == endPoint.Key && startPoint.Value == endPoint.Value) {
            throw new ArgumentException("The coordinates of points cannot match ");
        }

        this.startPoint = startPoint;
        this.endPoint = endPoint;

        Console.WriteLine("A line segment with StartPoint: (" + startPoint.Key + "," + startPoint.Value +
            ") and EndPoint: (" + endPoint.Key + "," + endPoint.Value + ") has been created");
    }

    public bool ContainsPoint(KeyValuePair<double, double> point) => new StraightLine(this).ContainsPoint(point) && 
        Math.Min(startPoint.Key, endPoint.Key) <= point.Key && point.Key <= Math.Max(startPoint.Key, endPoint.Key);
    public static bool ContainsPointOfIntersection(LineSegment segment1, LineSegment segment2) 
    {
        StraightLine ABline = new StraightLine(segment1);
        StraightLine CDline = new StraightLine(segment2);

        if (StraightLine.IsParallel(ABline, CDline))
        {
            Console.WriteLine("As the line AB is Parallel to the line CD -> the point of intersection does not exist in the context of the task given");
            return false; 
        }
      
        KeyValuePair<double, double> pointOfIntersection = StraightLine.PointOfIntersection(ABline, CDline);

        Console.WriteLine("Point of intersection coordinates: (" +
            pointOfIntersection.Key + "," + pointOfIntersection.Value + ")");

        bool flag = segment1.ContainsPoint(pointOfIntersection) && segment2.ContainsPoint(pointOfIntersection);

        if (flag)
        {
            AddTask3.Quarter(pointOfIntersection);
            return true;
        }
        else  return false;       
    }
}

