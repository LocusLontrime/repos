namespace AuxLib 
{
    public class Lib    
    {
        static void Main(string[] args)
        {

        }

    public static int[] ArrayRandomFulfilling(int array_length)
        {
            Random random = new Random();

            int[] array = new int[array_length];

            for (int i = 0; i < array_length; i++)
            {
                array[i] = (int)(random.Next(1, array_length));
            }

            return array;
        }
        public static void PrintArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
    }
}