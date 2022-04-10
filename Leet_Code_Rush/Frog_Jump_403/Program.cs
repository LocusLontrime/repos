public class FrogJump403 // 366 36 98
{
    public static Dictionary<int, HashSet<int>> map;

    static void Main(string[] args)
    {
        int[] stones = new int[] { 0, 1, 3, 5, 6, 8, 12, 17 };

        Console.WriteLine(CanCross(stones));

        stones = new int[] { 0, 1, 2, 3, 4, 8, 9, 11 };

        Console.WriteLine(CanCross(stones));
    }

    public static bool CanCross(int[] stones) 
    { 
        map = new Dictionary<int, HashSet<int>>();

        MapInitialization(stones);

        map[1].Add(1);

        RecSeeker(1, stones);

        return map[stones[stones.Length - 1]].Count > 0;
    }

    public static void RecSeeker(int index, int[] stones)
    {
        if (index >= stones.Length) return;

        foreach (var k in map[stones[index]]) // cycling over all elements located in the corresponding set
        {
            for (int jumpLength = k - 1; jumpLength <= k + 1; jumpLength++) 
            {
                if (jumpLength > 0 && map.ContainsKey(stones[index] + jumpLength))
                {
                    map[stones[index] + jumpLength].Add(jumpLength);
                }
            }
        }

        RecSeeker(index + 1, stones); // next step through the stones array's elements
    }

    public static void MapInitialization(int[] stones) 
    {
        for (int i = 0; i < stones.Length; i++) 
        {
            map.Add(stones[i], new HashSet<int>());
        }
    }
}