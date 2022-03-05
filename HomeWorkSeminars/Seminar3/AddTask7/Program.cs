public class AddTask7 // Из центра координат к точке А(x, y) проведён отрезок АО.
                      // Напишите программу, определяющую наименьший угол наклона отрезка AO к оси X
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter coordinates (X,Y) of the point A: ");
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());

        Console.WriteLine(MinAngleDegrees(X, Y)); // method call
    }

    public static double MinAngleDegrees(int X, int Y) => (180 * Math.Atan(1.0 * Math.Abs(Y) / Math.Abs(X)) / Math.PI); // finds the min angle with 
                                                                                                                        // Abscissa axis, converts Radians
                                                                                                                        // to Degrees
}