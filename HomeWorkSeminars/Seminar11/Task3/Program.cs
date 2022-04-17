public class Task3 // Напишите рекурсивный метод, который принимает номер года и определяет,
                   // является ли он високосным или нет
{
    static void Main(string[] args) // простейшая проверка на делимость, зачем здесь рекурсия?..
    {
        Console.WriteLine(IsYearLeap(1888));
    }

    public static bool IsYearLeap(int year)
    {
        if (year % 100 == 0) return year % 400 == 0;
        return year % 4 == 0;
    }
}