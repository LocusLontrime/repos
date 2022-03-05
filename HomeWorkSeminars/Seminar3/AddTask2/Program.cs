public class AddTask3 // Решить задачу 1 для n точек
{
    static void Main(string[] args) // more interesting way to solve (brute farce -> runtime: O(n!))
    {
        Console.WriteLine("Задайте номер координатной четверти: ");
        int quarter = int.Parse(Console.ReadLine());

        int xMultiple, yMultiple;

        switch (quarter) // here we r defining mulripliers for all coordinate quarters
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

        Console.WriteLine("Задайте количество точек: "); // taking into consideration factorial runtime
                                                         // we should not make the quantity of points very large
                                                         // (less than 12)
        int quantity = int.Parse(Console.ReadLine());

        List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();

        for (int i = 0; i < quantity; i++)
        {
             list.Add(new KeyValuePair<int, int>(xMultiple * random.Next(10000), yMultiple * random.Next(10000))); // adding all the points into the list
        }

        Console.WriteLine("Minimal Distance: " + RecursiveSeeker(list, new KeyValuePair<int, int>(0, 0)));
    }

    public static double RecursiveSeeker(List<KeyValuePair<int, int>> list, KeyValuePair<int, int> prevPair) // the main method that computes
                                                                                                             // the minimal final distance
    {
        List <KeyValuePair<int, int>> newList = new List<KeyValuePair<int, int>>(); // auxiliary list

        if (list.Count == 0) return 0;

        double minDistance = 1000000001d;

        foreach (KeyValuePair<int, int> kvp in list) // cycling all over the list elements
        {
            newList.Remove(kvp); // here we are sequentially deleting the list elements and getting exactly list.Count newLists

            double currentValue = Distance(prevPair, kvp) + RecursiveSeeker(newList, kvp);

            // Console.WriteLine("Currect Value = " + currentValue);

            minDistance = Math.Min(minDistance, currentValue); // step of decision making, here we are choosing the minimal distance path
                                                               // through the all points given

            newList = new List<KeyValuePair<int, int>>(list);
        }

        return minDistance;
    }

    public static double Distance(KeyValuePair<int, int> pair1, KeyValuePair<int, int> pair2) // calculates a distance between two points in 2D-space
    {
        return Math.Sqrt((pair1.Key - pair2.Key) * (pair1.Key - pair2.Key) + (pair1.Value - pair2.Value) * (pair1.Value - pair2.Value));
    }
}

