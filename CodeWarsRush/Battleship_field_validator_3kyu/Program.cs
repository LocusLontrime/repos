public class BattleshipFieldValidator 
{
    public static int[,] grid;
    public static SortedDictionary<int, int> ships;

    public static int jMax, iMax;
    public static int[] dirs;
    public static int currShipLength;

    static void Main(string[] args) // accepted on codewars.com
    {
        int[,] field = new int[10, 10]
        {
            {1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
            {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
            {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
            {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        Console.WriteLine(ValidateBattlefield(field));
    }

    public static bool ValidateBattlefield(int[,] field) // the main method
    {
        // Write your magic here
        jMax = field.GetLength(0);
        iMax = field.GetLength(1);

        if (TouchOrNot(field)) return false;

        ships = new SortedDictionary<int, int>();

        for (int j = 0; j < jMax; j++) 
        {
            for (int i = 0; i < iMax; i++)
            {
                if (field[j, i] != 0) 
                {
                    currShipLength = 0;

                    dirs = new int[2] { 0, 0 };

                    dfs(j, i, field, 0);

                    if (dirs[0] + dirs[1] > 1 || currShipLength > 4) return false;
                    else
                    {
                        if (ships.ContainsKey(currShipLength)) ships[currShipLength]++;
                        else ships.Add(currShipLength, 1);
                    }
                }
            }
        }

        foreach (var kvp in ships)
        {

            Console.WriteLine(kvp.Key + " " + kvp.Value);

        }

        if (ships.Count != 4) return false;

        int index = 1;

        foreach (var kvp in ships) 
        { 
            if (kvp.Key != index || kvp.Value != 5 - index) return false;
            index++;
        }

        return true;
    }

    public static void dfs(int j, int i, int[,] field, int dir) // searching engine
    {
        if (j >= 0 && i >= 0 && j < jMax && i < iMax && field[j, i] == 1) 
        {
            field[j, i] = 0; // memoization
            if (dir == 1) dirs[0] = 1;
            else if (dir == -1) dirs[1] = 1;

            if (dirs[0] + dirs[1] > 1) return;

            currShipLength++;

            dfs(j + 1, i, field, 1); // bot-up
            dfs(j - 1, i, field, 1);

            dfs(j, i + 1, field, -1); // right-left
            dfs(j, i - 1, field, -1);
        } 
    }

    public static bool TouchOrNot(int[,] field) // diag touching
    {
        for (int j = 0; j < jMax - 1; j++)
        {
            for (int i = 0; i < iMax - 1; i++)
            {
                // Console.WriteLine(field[j, i] + " " + field[j, i + 1]);
                // Console.WriteLine(field[j + 1, i] + " " + field[j + 1, i + 1]);

                if (field[j, i] == 1 && field[j, i + 1] == 0 && field[j + 1, i] == 0 && field[j + 1, i + 1] == 1) return true;
                if (field[j, i] == 0 && field[j, i + 1] == 1 && field[j + 1, i] == 1 && field[j + 1, i + 1] == 0) return true;
            }
        }

        return false;
    }
}