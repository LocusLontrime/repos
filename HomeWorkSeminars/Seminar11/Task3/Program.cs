public class Task3 // Напишите рекурсивный метод, который принимает номер года и определяет,
                   // является ли он високосным или нет
{
    static void Main(string[] args) // простейшая проверка на делимость, зачем здесь рекурсия?..
    {
        Console.WriteLine(IsYearLeap(1888));

        Console.WriteLine("\n" + IsYearLeapRec(1888));
    }

    public static bool IsYearLeap(int year) // a fast and good method
    {
        if (year % 100 == 0) return year % 400 == 0;
        return year % 4 == 0;
    }

    public static bool IsYearLeapRec(int year) // rec method, just a study case
    { 
        if (year > 400) return IsYearLeap(year - 400);
        else if (year == 400) return true;
        else if (year > 100) return IsYearLeap(year - 100);
        else if (year == 100) return false;
        else if (year > 4) return IsYearLeap(year - 4);
        else if (year == 4) return true;
        else return false;
    }
}