public class AddTask1 // На ввод подаётся номер четверти. Создаются 3 случайные точки в этой четверти. Определите самый оптимальный
                      // маршрут для торгового менеджера, который выезжает из центра координат
{
    static void Main(string[] args)
    {

        Console.WriteLine("Задайте номер координатной четверти: ");
        int quarter = int.Parse(Console.ReadLine());

        int xMultiple, yMultiple;

        switch (quarter) 
        {

            case 1:
                xMultiple = 1;
                yMultiple = 1;
                break;
            case 2:
                xMultiple = -1;
                yMultiple = 1;
                break;
            case 3:
                xMultiple = -1;
                yMultiple = -1;
                break;
            case 4:
                xMultiple = 1;
                yMultiple = -1;
                break;
            default:
                xMultiple = 0;
                yMultiple = 0;
                break;
        }

        Random random = new Random();

        int xa = xMultiple * random.Next(10000);
        int ya = yMultiple * random.Next(10000);

        int xb = xMultiple * random.Next(10000);
        int yb = yMultiple * random.Next(10000);

        int xc = xMultiple * random.Next(10000);
        int yc = yMultiple * random.Next(10000);

        Console.WriteLine("Coordinates-> A: (" + xa + "," + ya + ") B: (" + xb + "," + yb + ") C: (" + xc + "," + yc + ")");

        double[] array = new double[6];

        double minDistance = 1000000;
        int minIndex = 0;

        array[0] = distance(xa, 0, ya, 0) + distance(xa, xb, ya, yb) + distance(xb, xc, yb, yc);
        array[1] = distance(xa, 0, ya, 0) + distance(xa, xc, ya, yc) + distance(xb, xc, yb, yc);
        array[2] = distance(xb, 0, yb, 0) + distance(xb, xa, yb, ya) + distance(xa, xc, ya, yc);
        array[3] = distance(xb, 0, yb, 0) + distance(xc, xb, yc, yb) + distance(xa, xc, ya, yc);
        array[4] = distance(xc, 0, yc, 0) + distance(xc, xb, yc, yb) + distance(xb, xa, yb, ya);
        array[5] = distance(xc, 0, yc, 0) + distance(xa, xc, ya, yc) + distance(xb, xa, yb, ya);

        for (int i = 0; i < array.Length; i++)
        {
            if (minDistance > array[i]) 
            { 
                minDistance = array[i];
                minIndex = i;
            }
        }

        switch (minIndex) 
        { 
            case 0:
                Console.WriteLine("Min distance abc = " + (int) minDistance);
                break;
            case 1:
                Console.WriteLine("Min distance acb = " + (int) minDistance);
                break;
            case 2:
                Console.WriteLine("Min distance bac = " + (int) minDistance);
                break;
            case 3:
                Console.WriteLine("Min distance bca = " + (int) minDistance);
                break;
            case 4:
                Console.WriteLine("Min distance cba = " + (int) minDistance);
                break;
            case 5:
                Console.WriteLine("Min distance cab = " + (int) minDistance);
                break;
        }      
    }

    public static double distance(int x1, int x2, int y1, int y2) 
    {
        return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
}