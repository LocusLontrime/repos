public class CoinPath656 // 366
{
    public static long[] memoTable; // accepted (speed: 199ms, beats 100% of C# submissions) -> solve the problem of endless recursion
                                    //                                                          in the -1 final point case

    static void Main(string[] args)
    {
        int[] coins = new int[] {14, 86, 57, 47, 99, 64, 41, 77, 58, 2, 54, 89, 26, 99, 54, 64, 37, 41, 82, 50, 93, 
            99, 49, 53, 44, 65, -1, 88, 71, 42, 30, 65, 98, 13, 58, 13, 27, 59, 35, 28, 34, 75, 1, 47, 91, 66, 76, 
            49, 65, 98, 77, 90, 31, 8, -1 }; // { 1, 2, 4, -1, 2 };

        int maxJump = 5;

        foreach (var item in CheapestJump(coins, maxJump))
        {
            Console.Write(item + " ");
        }
    }

    public static IList<int> CheapestJump(int[] coins, int maxJump)
    {
        if (coins[coins.Length - 1] == -1) return new List<int> (); // if there is no way (-1 is in the end) 

        int[] array = new int[coins.Length];
        memoTable = new long[coins.Length];

        List<int> list = new List<int>();

        Array.Fill(array, -1); // initial filling
        Array.Fill(memoTable, 0);

        CoinJumpsCostRec(0, maxJump, coins, array);// recursion call

        int index;

        for (index = 0; index < coins.Length && array[index] > 0; index = array[index]) 
        { 
            list.Add(index + 1); // + 1 as we should add the number of position and they are natural ones and start with 1, not 0.
        }      

        if (index == array.Length - 1 && coins[coins.Length - 1] >= 0) // if we reach the last index and it is not prohibited by -1 value
        {
            list.Add(array.Length);
        }
        else 
        {
            return new List<int>(); // an empty list if there no pass exists
        }

        return list; // return the list built
    }

    public static long CoinJumpsCostRec(int i, int maxJump, int[] coins, int[] array) 
    {
        if (memoTable[i] > 0) // memoed case
        {
            return memoTable[i];
        }

        if (i == coins.Length - 1 && coins[i] >= 0) // border case
        {
            {
                memoTable[i] = coins[i];
                return coins[i]; 
            }
        }

        long minCost = long.MaxValue; // initial value of minCost is equal to Max value of a long class
            
        for (int j = i + 1; j <= i + maxJump && j < coins.Length; j++) // cycling all over all possible jump lengths
                                                                        // from a current position
        {
            if (coins[j] >= 0) // if the location is not prohibited by -1 value
            {
                long currCost = coins[i] + CoinJumpsCostRec(j, maxJump, coins, array); // next possible cost

                if (currCost < minCost) // if next possible cost is lower than minCost then ->
                {
                    minCost = currCost;

                    array[i] = j; // fills the indexes array
                }
            }
        }       

        memoTable[i] = minCost;
        return minCost;
    }
}
