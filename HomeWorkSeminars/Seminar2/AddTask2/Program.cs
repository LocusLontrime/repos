public class AddTask2 // Решить задачу 1 для n точек
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

        Console.WriteLine("Задайте количество точек: ");
        int quantity = int.Parse(Console.ReadLine());

        List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();

        for (int i = 0; i < quantity; i++)
        {
             list.Add(new KeyValuePair<int, int>(xMultiple * random.Next(10000), yMultiple * random.Next(10000)));
        }

        Console.WriteLine("Minimal Distance: " + RecursiveSeeker(list, new KeyValuePair<int, int>(0, 0)));
    }

    public static double RecursiveSeeker(List<KeyValuePair<int, int>> list, KeyValuePair<int, int> prevPair) 
    {
        List <KeyValuePair<int, int>> newList = new List<KeyValuePair<int, int>>();

        double minDistance = 0;

        foreach (KeyValuePair<int, int> kvp in list) 
        {
            newList.Remove(kvp);

            minDistance = Math.Min(minDistance, Distance(prevPair, kvp) + RecursiveSeeker(newList, kvp));

            newList = new List<KeyValuePair<int, int>>(list);
        }

        return minDistance;
    }

    public static double Distance(KeyValuePair<int, int> pair1, KeyValuePair<int, int> pair2)
    {
        return Math.Sqrt((pair1.Key - pair2.Key) * (pair1.Key - pair2.Key) + (pair1.Value - pair2.Value) * (pair1.Value - pair2.Value));
    }
}

