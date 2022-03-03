public class PaintHouseIII1473
{
    public static int[,,] memoTable;
    public static int MaxValue = 10000001;
    static void Main(string[] args)
    {
        int[] houses = new int[] { 3, 1, 2, 3}; // { 0, 2, 1, 2, 0 }; // { 0, 0, 0, 0, 0 }; // { 0, 2, 1, 2, 0 }; // { 0, 0, 0, 0, 0 }; // { 0, 2, 1, 2, 0 };
        int[,] cost = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int target = 3;
        int m = 4, n = 3;

        Console.WriteLine(minCost(houses, cost, m, n, target));
    }

    public static int minCost(int[] houses, int[,] cost, int m, int n, int target)
    {
        memoTable = new int[m, n + 1, target + 1];

        int result = MaxValue;     
        
        result = Math.Min(result, recursiveSeeker(m - 1, 0, target, houses, cost, m, n));
        
        return result == MaxValue ? -1 : result;
    }

    public static int recursiveSeeker(int i, int j, int k, int[] houses, int[,] cost, int m, int n) 
    {
        if (i == 0) Console.WriteLine("i = 0 " + " k = " + k);
        if (i == -1 || k < 0) return k == 0 ? 0 : MaxValue;
        

        if (memoTable[i, j, k] != 0) return memoTable[i, j, k];

        int result = MaxValue;

        if (houses[i] != 0) return recursiveSeeker(i - 1, houses[i], k - (j == houses[i] ? 0 : 1), houses, cost, m, n);
        for (int colour = 1; colour < n + 1; colour++)
        {
            int nextStepCost = recursiveSeeker(i - 1, colour, k - (j == colour ? 0 : 1), houses, cost, m, n);            
            result = Math.Min(result, cost[i, colour - 1] + nextStepCost);
        }   

        return memoTable[i, j, k] = result;
    }

}