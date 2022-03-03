public class Sem2AdditionalTask1 // Написать программу, которая определяет, является ли треугольник со сторонами a, b, c равнобедренным

{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter three numbers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        if (!IsTriangle(a, b, c)) Console.WriteLine("Numbers a, b, c cannot form a triangle");
        else if (IsEquilateral(a, b, c)) Console.WriteLine("The triangle abc is equilateral");
        else Console.WriteLine("The triangle abc is " + (IsIsosceles(a, b, c) ? "" : "not ") + "isosceles");
    }

    public static bool IsTriangle(int a, int b, int c) 
    {
        return a + b > c && a + c > b && b + c > a;
    }

    public static bool IsEquilateral(int a, int b, int c) 
    {
        return a == b && b == c;
    }
    public static bool IsIsosceles(int a, int b, int c) 
    { 
        return a == b || a == c || b == c;
    }

}