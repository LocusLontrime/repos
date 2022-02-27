namespace Sem1;

public class SemWork {

    static void Main(string[] args)
    {

        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        if (num1 == num2 * num2) Console.WriteLine("First number equals second one squared");
        else Console.WriteLine("First number does not equal second one squared");

        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());

        Console.WriteLine("Max num = " + Math.Max(num3, num4));
        Console.WriteLine("Min num = " + Math.Min(num3, num4));

        int num5 = int.Parse(Console.ReadLine());

       switch (num5)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default: Console.WriteLine("Do think twice before write it");
                    break;
            }

    }


}