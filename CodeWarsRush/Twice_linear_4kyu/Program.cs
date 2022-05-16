public class TwiceLinear // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(DblLinear(87));
    }

    public static int DblLinear(int n) 
    {
        List<int> numbers = new List<int>();
        
        numbers.Add(0);

        int counter2xNums = 0;
        int repeatsCount = 0;

        for (int i = 0; i <= n; i++) 
        { 
            int linear2x = 2 * numbers[counter2xNums] + 1;
            int linear3x = 3 * numbers[i + repeatsCount - counter2xNums] + 1;
            
            if (linear2x == linear3x)
            {
                numbers.Add(linear2x);

                counter2xNums++;
                repeatsCount++;

                continue;
            }
            else if (linear2x < linear3x)
            {
                numbers.Add(linear2x);
                counter2xNums++;

                continue;
            }
            
            numbers.Add(linear3x);
            
            Console.WriteLine($"c2x = {counter2xNums}, repeats count = {repeatsCount}, i = {i}");
        }

        return numbers[numbers.Count - 1];
    }
}