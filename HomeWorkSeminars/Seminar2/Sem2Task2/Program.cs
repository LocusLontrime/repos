public class Sem2Task2 //  Определить номер четверти плоскости, в которой находится точка с координатами Х и У, причем X ≠ 0 и Y ≠ 0
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("Enter a X coordinate, X ≠ 0: ");
        int X = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a Y coordinate, Y ≠ 0: ");
        int Y = int.Parse(Console.ReadLine());
        
        if (X > 0 && Y > 0) Console.WriteLine("<I> square");
        else if (X < 0 && Y > 0) Console.WriteLine("<II> square");
        else if (X < 0 && Y < 0) Console.WriteLine("<III> square");
        else if (X > 0 && Y < 0) Console.WriteLine("<IV> square");        
    }
}