using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StraightLine
{
    public double xCoefficient;
    public double yCoefficient;
    public double shift;
    public StraightLine()
    {
    }
    public StraightLine(LineSegment segment)
    {
        if (segment.startPoint.Key == segment.endPoint.Key) // straight line that is parallel to Ordinate axis
        {
            xCoefficient = 1;
            yCoefficient = 0;
            shift = segment.startPoint.Key;
            return;
        }

        if (segment.startPoint.Value == segment.endPoint.Value) // straight line that is parallel to Abscissa axis
        {
            xCoefficient = 0;
            yCoefficient = 1;
            shift = segment.startPoint.Value;
            return;
        }

        this.yCoefficient = 1;
        this.xCoefficient = (segment.startPoint.Value - segment.endPoint.Value) / (segment.startPoint.Key - segment.endPoint.Key);
        this.shift = (segment.startPoint.Value * segment.endPoint.Key - segment.endPoint.Value * segment.startPoint.Key) /
            (segment.endPoint.Key - segment.startPoint.Key);

        Console.WriteLine("Straight line with the equation: " + this.xCoefficient + "*x " + (this.shift > 0 ? "+ " : "- ") + Math.Abs(this.yCoefficient) +
            " = " + this.shift + " has been created");
    }
    public static KeyValuePair<double, double> PointOfIntersection(StraightLine line1, StraightLine line2)
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

    public double GetY(double x) {
        if (yCoefficient != 0) return (shift - xCoefficient * x) / yCoefficient;
        else 
        {
            throw new ArgumentException("yCoefficient is equal to zero!!!");
        }
    }
    public bool ContainsPoint(KeyValuePair<double, double> point) => xCoefficient * point.Key + yCoefficient * point.Value == shift;
    public static bool IsParallel(StraightLine line1, StraightLine line2) => line1.xCoefficient * line2.yCoefficient == line1.yCoefficient * line2.xCoefficient;   
}

