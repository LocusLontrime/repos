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

    public LineSegment(KeyValuePair<double, double> startPoint, KeyValuePair<double, double> endPoint) // constructor of LineSegments by two points
    {
        if (startPoint.Key == endPoint.Key && startPoint.Value == endPoint.Value) { // the same points throw an ArgumentException
            throw new ArgumentException("The coordinates of points cannot match ");
        }

        this.startPoint = startPoint;
        this.endPoint = endPoint;

        Console.WriteLine("A line segment with StartPoint: (" + startPoint.Key + "," + startPoint.Value + // printing info about creation
            ") and EndPoint: (" + endPoint.Key + "," + endPoint.Value + ") has been created");
    }

    public bool ContainsPoint(KeyValuePair<double, double> point) => new StraightLine(this, false).ContainsPoint(point) && // checks if the line segment contains
                                                                                                                           // the point given
        Math.Min(startPoint.Key, endPoint.Key) <= point.Key && point.Key <= Math.Max(startPoint.Key, endPoint.Key);
    public static bool ContainsPointOfIntersection(LineSegment segment1, LineSegment segment2) // checks if the both line segments contain the point of
                                                                                               // intersection of two straight lines created by these segments
    {
        StraightLine ABline = new StraightLine(segment1, true); // creation of a straight line that corresponds to a line segment given
        StraightLine CDline = new StraightLine(segment2, true);

        if (StraightLine.IsParallel(ABline, CDline)) // if the lines are parallel -> there is no point of intersection of them
        {
            Console.WriteLine("As the line AB is Parallel to the line CD or AB equals CD -> " +
                "the point of intersection does not exist in the context of the task given");
            return false; 
        }
      
        KeyValuePair<double, double> pointOfIntersection = StraightLine.PointOfIntersection(ABline, CDline);

        Console.WriteLine("Point of intersection coordinates: (" +
            pointOfIntersection.Key + "," + pointOfIntersection.Value + ")");

        bool flag = segment1.ContainsPoint(pointOfIntersection) && segment2.ContainsPoint(pointOfIntersection); // if both line segments contain
                                                                                                                // the point of intersection (that exists) then ->
                                                                                                                // we can define the number of coordinate quarter
                                                                                                                // it's located in
        if (flag)
        {
            AddTask2and4.Quarter(pointOfIntersection);
            return true;
        }
        else  return false;       
    }
}

