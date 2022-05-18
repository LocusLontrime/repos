public class SumOfIntervals // accepted on codewars.com
{
    static void Main(string[] args)
    {
        (int, int)[] intervals = new (int, int)[] 
        { 
            /* (-8984, -7820), (-8854, 4559), (-8422, 2573), (-8381, 430), 
            (-8325, 2887), (-8152, 7127), (-7883, 9993), (-6919, 9047), 
            (-6335, 6546), (-6189, 4242), (-5988, 7624), (-5149, 6167), 
            (-4490, 4391), (-4101, 495), (-3712, 4365), (-3567, -626), 
            (-3147, 2964), (-2277, -266), (-1962, 4115), (472, 2278), 
            (594, 8733), (2381, 7279), (2699, 7098), (3066, 9567),
            (3702, 6233), (6340, 9899), (6826, 6861), (7005, 8415), 
            (8600, 8819), (9811, 9902) */

            (1, 4), (3, 5), (7, 10)
        };

        Console.WriteLine($"sum = {SumIntervals(intervals)}");
    }

    public static int SumIntervals((int, int)[] intervals)
    {
        (int, int)[] sortedInts = intervals.OrderBy(x => x.Item1).ToArray();

        int intervalsSum = 0;

        (int, int) currInt = (0, 0);

        Console.WriteLine($"sorted array: {string.Join(" ", sortedInts)}");

        for (int i = 0; i < sortedInts.Count(); i++) 
        {
            if (i == 0) currInt = sortedInts[i];

            if (IsOverlapped(currInt, sortedInts[i]))
            {
                currInt = MergeInts(currInt, sortedInts[i]);
            } 
            else 
            {                 
                intervalsSum += currInt.Item2 - currInt.Item1;

                currInt = sortedInts[i];
            }

            Console.WriteLine(intervalsSum);
        }

        intervalsSum += currInt.Item2 - currInt.Item1; // the last one;

        return intervalsSum;
    }

    public static bool IsOverlapped((int, int) int1, (int, int) int2) => int1.Item2 > int2.Item1;

    public static (int, int) MergeInts((int, int) int1, (int, int) int2) => (int1.Item1, Math.Max(int1.Item2, int2.Item2));   
}