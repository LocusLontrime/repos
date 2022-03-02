public class Sem2AdditionalTask1 // Написать программу, которая определяет, является ли треугольник со сторонами a, b, c равнобедренным

{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter three numbers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("The triangle abc is " + (IsIsosceles(a, b, c) ? "" : "not ") + "isosceles");
    }

    public static bool IsIsosceles(int a, int b, int c) 
    { 
        return a == b || a == c || b == c;
    }

}