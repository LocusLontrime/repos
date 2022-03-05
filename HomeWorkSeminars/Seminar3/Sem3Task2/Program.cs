public class Sem3HomeTask2 // Найти расстояние между точками в пространстве 2D/3D, обобщена на эн-мерный случай
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number of Dimensions: ");
        int numberOfDims = int.Parse(Console.ReadLine());

        if (numberOfDims <= 0) Console.WriteLine("Enter a number larger than 0");
        else {

            Console.WriteLine("Every time firstly enter coordinate of first point and then second");

            int result = 0;

            for (int i = 0; i < numberOfDims; i++)
            {
                int deltaCoordinate = int.Parse(Console.ReadLine());
                deltaCoordinate -= int.Parse(Console.ReadLine());

                result += deltaCoordinate * deltaCoordinate;
            }

            Console.WriteLine("Distance between two points in = " + numberOfDims + "-D space = " + Math.Sqrt(result));
        }
    }
}