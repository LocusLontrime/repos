public class Maximum_Product_Subarray_152 { // accepted (speed: 80ms, very fast)

    public static void Main(string[] args)
    {
        int[] array = new int[] { 2, 3, -2, 4 }; // { -2, 0, -1 };        

        Console.WriteLine("Max product subbarray = " + MaxProduct(array));
    }

    public static int MaxProduct(int[] nums) // almost Kadane realization, O(n)
    {
        int maxProduct = 1, minProduct = 1, tempMax, tempMin, result = int.MinValue;

        for (int i = 0; i < nums.Length; i++) 
        { 
            tempMax = Math.Max(nums[i], Math.Max(maxProduct * nums[i], minProduct * nums[i]));
            tempMin = Math.Min(nums[i], Math.Min(maxProduct * nums[i], minProduct * nums[i]));

            result = Math.Max(result, tempMax);

            maxProduct = tempMax;
            minProduct = tempMin;
        }

       return result;
    }   
}