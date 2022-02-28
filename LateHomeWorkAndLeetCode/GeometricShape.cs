using System;
using System.Collections;

public class GeometricShape
{
    public static void Main(string[] args)
    {

        double k = 2.0;
        List<double[]> list = new List<double[]>();

        list.Add(new double[] { 0.0, 0.0 });
        list.Add(new double[] { 0.0, 2.0 });
        list.Add(new double[] { 2.0, 0.0 });
        list.Add(new double[] { 2.0, 2.0 });

        // Console.WriteLine(scale(list, k));
      
        printList(scale(list, k));

    }

    public static List<double[]> scale(List<double[]> list, double k) 
    {

        foreach (double[] pair in list)
        {
            pair[0] *= k;
            pair[1] *= k;
        }

        return list;
    }

    public static void printList(List<double[]> list)
    {

        foreach (double[] pair in list)
        {
            Console.Write("(" + pair[0] + "," + pair[1] + ")");
        }

        Console.WriteLine();
    }



































}
