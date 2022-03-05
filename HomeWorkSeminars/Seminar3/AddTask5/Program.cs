public class AddTask5 
{

    public static void Main(string[] args)
    {
        int[,] array = new int[10, 12];

        RandomArray2Dfulfilling(array, 25);

        DefineAverageTemperatures(array, 2, 2, 8, 9);
        DefineAverageTemperatures(array, 2, 2, 2, 6);
    }

    public static void RandomArray2Dfulfilling(int[,] array, int range) 
    {
        Random random = new Random();

        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                array[i, j] = random.Next(-range, range);      
    }

    public static void DefineAverageTemperatures(int[,] array, int startYear, int startMonth, int endYear, int endMonth) 
    {
        if (startYear <= 0 || endYear <= 0 || startYear > 10 || endYear > 10)
        {
            Console.WriteLine("Start or End year is out of range");
            return;
        }

        if (startMonth <= 0 || endMonth <= 0 || startMonth > 12 || endMonth > 12)
        {
            Console.WriteLine("Start or End month is out of range");
            return;
        }

        if (startYear == endYear && startMonth >= endMonth) 
        {
            Console.WriteLine("Interval given does not contain a natural number of months");
            return;
        }

        int j = startMonth - 1;

        double summerAvg = 0; // can be easily simplified to an array form
        double autumnAvg = 0;
        double winterAvg = 0;
        double springAvg = 0;

        double summerCounter = 0; // can be easily simplified to an array form
        double autumnCounter = 0;
        double winterCounter = 0;
        double springCounter = 0;

        for (int i = startYear - 1; i < endYear; i++) // cycling all over the interval
        {
            while (j >= 0 && j <= 1) // winter (january and february)
            {
                if (i == endYear - 1 && j == endMonth - 1) break;
                winterAvg += array[i, j++];
                winterCounter++;
            }

            while (j >= 2 && j <= 4) // spring
            {
                if (i == endYear - 1 && j == endMonth - 1) break;
                springAvg += array[i, j++];
                springCounter++;
            }

            while (j >= 4 && j <= 7) // summer
            {
                if (i == endYear - 1 && j == endMonth - 1) break;
                summerAvg += array[i, j++];
                summerCounter++;
            }

            while (j >= 8 && j <= 10) // autumn
            {
                if (i == endYear - 1 && j == endMonth - 1) break;
                autumnAvg += array[i, j++];
                autumnCounter++;
            }

            if (i == endYear - 1 && j == endMonth - 1) break; // winter (december)
            winterAvg += array[i, j++];
            winterCounter++;

            j = 0; // nullify j-counter before the next step of the cycle
        }

        Console.WriteLine("Average temperatures per season: ");

        if (summerCounter > 0) Console.WriteLine("summerCounter average temperature = " + String.Format("{0:f2}", summerAvg / summerCounter));
        if (autumnCounter > 0) Console.WriteLine("autumnCounter average temperature = " + String.Format("{0:f2}", autumnAvg / autumnCounter));
        if (winterCounter > 0) Console.WriteLine("winterCounter average temperature = " + String.Format("{0:f2}", winterAvg / winterCounter));
        if (springCounter > 0) Console.WriteLine("springCounter average temperature = " + String.Format("{0:f2}", springAvg / springCounter));
    }
}
