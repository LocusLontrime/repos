using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StraightLine
{
    public double angleCoefficient;
    public double shift;
    public StraightLine() 
    { 
    }
    public StraightLine(LineSegment segment) 
    { 
        this.angleCoefficient = (segment.startPoint.Value - segment.endPoint.Value) / (segment.startPoint.Key - segment.endPoint.Key);
        this.shift = (segment.startPoint.Value * segment.endPoint.Key - segment.endPoint.Value * segment.startPoint.Key) / 
            (segment.endPoint.Key - segment.startPoint.Key);
    }
    public static KeyValuePair<double, double> PointOfIntercection(StraightLine line1, StraightLine line2)
    {
        if (isParallel(line1, line1)) 
        {
            Console.WriteLine("Staights lines are paralle");
            return new KeyValuePair<double, double>(0, 0);
        }

        KeyValuePair<double, double> pointOfIntercection;

        double xOfIntercection = (line2.shift - line1.shift) / (line2.angleCoefficient - line1.angleCoefficient);

        pointOfIntercection = new KeyValuePair<double, double>(xOfIntercection, line1.getY(xOfIntercection));

        return pointOfIntercection;
    }
    public double getY(double x) => x * this.angleCoefficient + this.shift;
    public bool containsPoint(KeyValuePair<double, double> point) => point.Value == this.getY(point.Key);
    public static bool isParallel(StraightLine line1, StraightLine line2) => line1.angleCoefficient == line2.angleCoefficient;   
}

