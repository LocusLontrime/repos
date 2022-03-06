public class PaintHouseIII1473 // accepted (speed: 112ms, ultra-fast, beats 97,7% of c# submissions)
{
    public static int[,,] memoTable;
    public static int MaxValue = 10000001;
    static void Main(string[] args)
    {
        int[] houses = new int[] { 3, 1, 2, 3}; // { 0, 2, 1, 2, 0 }; // { 0, 0, 0, 0, 0 }; // { 0, 2, 1, 2, 0 }; // { 0, 0, 0, 0, 0 }; // { 0, 2, 1, 2, 0 };
        int[,] cost = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int target = 3;
        int m = 4, n = 3;

        Console.WriteLine(minCost(houses, cost, m, n, target)); // method call
    }

    public static int minCost(int[] houses, int[,] cost, int m, int n, int target)
    {
        memoTable = new int[m, n + 1, target + 1]; // initialization of dp memoTable

        int result = MaxValue; // a convenient value< it's greater than potentially possible maxCost and less than int.MaxValue so than its value cannot exceed the int limit     
        
        result = Math.Min(result, recursiveSeeker(m - 1, 0, target, houses, cost, m, n)); // initial rec call
        
        return result == MaxValue ? -1 : result; // return value, if task has no solution we return -1
    }

    // rec (i, j, k) signifies: minCost of painting i adjacent houses (beginning from index 0 in houses array) where the rightmost house painted in colour j 
    // in order to achieve exactly k neighbourhoods 
    public static int recursiveSeeker(int i, int j, int k, int[] houses, int[,] cost, int m, int n) // recursive dynamic programming
    {        
        if (i == -1 || k < 0) return k == 0 ? 0 : MaxValue; // base cases: 1. if we at i == -1 then k must be equal to 0,
                                                            // if i != 0 and k < 0 then this is the wrong branch with no solution
        
        if (memoTable[i, j, k] != 0) return memoTable[i, j, k]; // if we has already calculated the minCost at this step then we just use it

        int result = MaxValue;

        if (houses[i] != 0) return recursiveSeeker(i - 1, houses[i], k - (j == houses[i] ? 0 : 1), houses, cost, m, n); // if the house has been already painted then
                                                                                                                        // we cant pain it again and pay no cost
        for (int colour = 1; colour < n + 1; colour++) // cycling over all colours given
        {
            int nextStepCost = recursiveSeeker(i - 1, colour, k - (j == colour ? 0 : 1), houses, cost, m, n); // next step of recursion (i -> i - 1), if these adjacent houses (i and i - 1)
                                                                                                              // painted in the same colour then when we proceeding
                                                                                                              // to the next rec step we do not decrease k (target) value,
                                                                                                              // otherwise, if the colours differ -> we decrease k by one: k -> k-1
            result = Math.Min(result, cost[i, colour - 1] + nextStepCost);
        }   

        return memoTable[i, j, k] = result; // return calculated memo value
    }
}