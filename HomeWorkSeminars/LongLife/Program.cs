public class LongLife 
{
    static void Main(string[] args)
    {
        DateTime dateTime1 = new DateTime(1992, 10, 11);

        DateTime dateTime2 = new DateTime(1992, 10, 12);

        Console.WriteLine(GetLifeHours(dateTime1, dateTime2));
    }

    public static int GetLifeHours(DateTime d1, DateTime d2) 
    {
        TimeSpan interval = d2 - d1;

        return (int) interval.TotalHours;
    }
}
