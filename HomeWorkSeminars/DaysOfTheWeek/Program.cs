public class DaysOfTheWeek { // Вывести название дня недели по его порядковому номеру

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the day of the week (number)");
        int dayNumber = int.Parse(Console.ReadLine());

        switch (dayNumber) 
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
            default: // whem we are out of range
                Console.WriteLine("Do think twice before write it");
                break;
        }
    }
}