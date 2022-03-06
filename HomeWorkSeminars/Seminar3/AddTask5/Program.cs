public class AddTask5 // Дан массив средних температур (массив заполняется случайно) за последние 10 лет.
                      // На ввод подают номер месяца и год начали и конца. Определить самые высокие и низкие температуры
                      // для лета, осени, зимы и весны в заданном промежутке. Если таких температур нет, сообщить, что определить не удалось.

{
    public static void Main(string[] args)
    {
        int[,] array = new int[10, 12];

        RandomArray2Dfulfilling(array, 25); // random array generation

        DefineMinAndMaxTemperatures(array, 2, 2, 8, 9); // menhod call and some testing
        DefineMinAndMaxTemperatures(array, 2, 2, 2, 6);

        DefineMinAndMaxTemperatures(array, 2, 3, 2, 12);
    }

    public static void RandomArray2Dfulfilling(int[,] array, int range) // method, than fullfil a 2D-array randomly
    {
        Random random = new Random();

        for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                array[i, j] = random.Next(-range, range); // random generation within the range given     
    }

    public static void DefineMinAndMaxTemperatures(int[,] array, int startYear, int startMonth, int endYear, int endMonth) // main calculating method
    {
        if (startYear <= 0 || endYear <= 0 || startYear > 10 || endYear > 10) // checks the input data
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

        bool flag = false;

        double summerMax = 0; // can be easily simplified to an array form
        double autumnMax = 0;
        double winterMax = 0;
        double springMax = 0;

        double summerMin = 0; // can be easily simplified to an array form
        double autumnMin = 0;
        double winterMin = 0;
        double springMin = 0;

        int summerCounter = 0; // can be easily simplified to an array form
        int autumnCounter = 0;
        int winterCounter = 0;
        int springCounter = 0;

        for (int i = startYear - 1; i < endYear; i++) // cycling all over the interval
        {
            while (j >= 0 && j <= 1) // winter (january and february)
            {
                if (i == endYear - 1 && j == endMonth - 1) flag = true;
                winterMax = Math.Max(winterMax, array[i, j]); 
                winterMin = Math.Min(winterMin, array[i, j++]);
                if (flag) break;
                winterCounter++;
            }

            while (j >= 2 && j <= 4) // spring
            {
                if (i == endYear - 1 && j == endMonth - 1) flag = true;
                springMax = Math.Max(springMax, array[i, j]);  
                springMin = Math.Min(springMin, array[i, j++]);
                if (flag) break;
                springCounter++;
            }

            while (j >= 5 && j <= 7) // summer
            {
                if (i == endYear - 1 && j == endMonth - 1) flag = true;
                summerMax = Math.Max(summerMax, array[i, j]);
                summerMin = Math.Min(summerMin, array[i, j++]);
                if (flag) break;
                summerCounter++;
            }

            while (j >= 8 && j <= 10) // autumn
            {
                if (i == endYear - 1 && j == endMonth - 1) flag = true;
                autumnMax = Math.Max(autumnMax, array[i, j]);
                autumnMin = Math.Min(autumnMin, array[i, j++]);
                if (flag) break;
                autumnCounter++;
            }

            if (i == endYear - 1 && j == endMonth - 1) flag = true; // winter (december)
            winterMax = Math.Max(winterMax, array[i, j]);
            winterMin = Math.Min(winterMin, array[i, j++]);
            winterCounter++;
            if (flag) break;
            
            j = 0; // nullify j-counter before the next step of the cycle
        }

        Console.WriteLine("Average temperatures per season: "); // printing the results

        if (summerCounter > 0) Console.WriteLine("summer Max temperature = " + summerMax + " Min = " + summerMin + " counted " + summerCounter + " times");
        if (autumnCounter > 0) Console.WriteLine("autumn Max temperature = " + autumnMax + " Min = " + autumnMin + " counted " + autumnCounter + " times");
        if (winterCounter > 0) Console.WriteLine("winter Max temperature = " + winterMax + " Min = " + winterMin + " counted " + winterCounter + " times");
        if (springCounter > 0) Console.WriteLine("spring Max temperature = " + springMax + " Min = " + springMin + " counted " + springCounter + " times");
    }
}
