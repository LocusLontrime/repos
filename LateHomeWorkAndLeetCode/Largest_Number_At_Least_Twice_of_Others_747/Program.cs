public class LargestNumberAtLeastTwiceofOthers747 // accepted (speed: 64ms, very fast, beats 99,56% of c# submissions)
{
    static void Main(string[] args)
    {
        Console.WriteLine(DominantIndex(new int[] { 0, 0, 3, 2 })); //{1, 2, 3, 4})); // { 3, 6, 1, 0 }));
    }

    public static int DominantIndex(int[] nums)
    {
        if (nums.Length == 1) return 0;

        int n = nums.Length;
        int indexMax = 0;
        int indexSubMax = nums[0] < nums[n - 1] ? 0 : n - 1;

        for (int i = 0; i < n; i++) if (nums[i] >= nums[indexMax]) indexMax = i;
        for (int i = 0; i < n; i++) if (nums[i] >= nums[indexSubMax] && nums[i] != nums[indexMax]) indexSubMax = i;

        Console.WriteLine("indexSubMax = " + indexSubMax + " indexMax = " + indexMax);

        if (2 * nums[indexSubMax] <= nums[indexMax]) return indexMax;
        else return -1;
    }
}

