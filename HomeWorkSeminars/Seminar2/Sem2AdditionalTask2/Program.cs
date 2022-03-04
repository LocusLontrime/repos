public class Sem2AdditionalTask2 // На вход подаются год, номер месяца и день рождения человека, Определить возраст человека на момент 1 февраля 2022 года
{
    static void Main(string[] args)
    {
        int year = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int day = int.Parse(Console.ReadLine());

        Console.WriteLine((2022 - year) - (month < 2 || month == 2 && day == 1 ? 0 : 1));
    }
}