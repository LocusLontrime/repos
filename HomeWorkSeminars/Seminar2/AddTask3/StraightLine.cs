using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StraightLine
{
    public double xCoefficient; // >A<x + Bx = k
    public double yCoefficient; // Ax + >B<y = k
    public double shift;        // Ax + By = >k<
    public StraightLine()
    {
    }
    public StraightLine(LineSegment segment, bool isPrint) // constructor with boolean flag of printing
    {
        if (segment.startPoint.Key == segment.endPoint.Key) // straight line that is parallel to Ordinate axis
        {
            xCoefficient = 1;
            yCoefficient = 0;
            shift = segment.startPoint.Key;

        } else if (segment.startPoint.Value == segment.endPoint.Value) // straight line that is parallel to Abscissa axis
        {
            xCoefficient = 0;
            yCoefficient = 1;
            shift = segment.startPoint.Value;           
        } else
        {
            this.yCoefficient = 1;
            this.xCoefficient = -(segment.startPoint.Value - segment.endPoint.Value) / (segment.startPoint.Key - segment.endPoint.Key);
            this.shift = (segment.startPoint.Value * segment.endPoint.Key - segment.endPoint.Value * segment.startPoint.Key) /
                (segment.endPoint.Key - segment.startPoint.Key);

            if (xCoefficient < 0 && yCoefficient < 0 && shift < 0) // for convenient math and print
            {
                Console.WriteLine("lala");
                xCoefficient = -xCoefficient;
                yCoefficient = -yCoefficient;
                shift = -shift;
            }
        }

        if (isPrint) Console.WriteLine("Straight line with the equation: " + this.xCoefficient + "*x " + (this.yCoefficient >= 0 ? "+ " : "- ") + Math.Abs(this.yCoefficient) +
            "*y = " + this.shift + " has been created"); // printing
    }
    public static KeyValuePair<double, double> PointOfIntersection(StraightLine line1, StraightLine line2) // searching for the point of intersection
                                                                                                           // line1 and line2
    {
        if (IsParallel(line1, line2))
        {
            Console.WriteLine("Staights lines are parallel");
            return new KeyValuePair<double, double>(0, 0);
        }

        KeyValuePair<double, double> pointOfIntercection;

        double xOfIntercection = (line2.yCoefficient * line1.shift - line1.yCoefficient * line2.shift) / // Ax + By = k1 and Cx + Dy = k2, AD != BC, as
                                                                                                         // straight lines are not parallel
            (line2.yCoefficient * line1.xCoefficient - line1.yCoefficient * line2.xCoefficient);

        pointOfIntercection = new KeyValuePair<double, double>(xOfIntercection, line1.GetY(xOfIntercection));

        return pointOfIntercection;
    }

    public double GetY(double x) { // tries to find Y value
        if (yCoefficient != 0) return (shift - xCoefficient * x) / yCoefficient;
        else 
        {
            throw new ArgumentException("yCoefficient is equal to zero!!!");
        }
    }
    public bool ContainsPoint(KeyValuePair<double, double> point) => xCoefficient * point.Key + yCoefficient * point.Value == shift; // checks if the straight line contains
                                                                                                                                     // the point given
    public static bool IsParallel(StraightLine line1, StraightLine line2) => line1.xCoefficient * line2.yCoefficient == // checks if line1 || line2
        line1.yCoefficient * line2.xCoefficient;   
}

