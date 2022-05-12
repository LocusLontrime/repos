using System.Drawing;

public class FindTheCheapestPath 
{
    public static int counterRec;

    public static int jMax, iMax;

    public static int[,] memoTable;

    public static List<String> finalSeq;

    public static Point finishPoint;

    static void Main(string[] args)
    {
        int[,] matrix = new int[,]
        {
            { 1, 9, 1},
            { 2, 9, 1},
            { 2, 1, 1}
        };

        matrix = new int[,]
        {
            {1, 4, 1},
            {1, 9, 1},
            {1, 1, 1}
        };

        matrix = GetRandomMatrix(20);

        counterRec = 0;

        foreach (var item in CheapestPath(matrix, new Point(0, 0), new Point(10, 12)))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nCost: " + memoTable[0, 2] + " counter Rec = " + counterRec);
    }

    public static List<String> CheapestPath(int[,] matrix, Point start, Point finish)
    {
        jMax = matrix.GetLength(0);
        iMax = matrix.GetLength(1);

        memoTable = new int[jMax, iMax];
        MemoFill();

        finishPoint = finish;

        RecSeeker(start.X, start.Y, new List<String>(), matrix, 0);

        return finalSeq;
    }

    public static void RecSeeker(int j, int i, List<String> currWay, int[,] matrix, int currentPrice)
    {
        counterRec++;

        if (j >= 0 && i >= 0 && j < jMax && i < iMax)
        {
            if (memoTable[j, i] > currentPrice)
            {
                memoTable[j, i] = currentPrice;

                if (finishPoint.X == j && finishPoint.Y == i) finalSeq = new List<String>(currWay);

                List<String> newCurrWay;

                newCurrWay = new List<String>(currWay);
                newCurrWay.Add("down");
                RecSeeker(j + 1, i, newCurrWay, matrix, currentPrice + matrix[j, i]);

                newCurrWay = new List<String>(currWay);
                newCurrWay.Add("right");
                RecSeeker(j, i + 1, newCurrWay, matrix, currentPrice + matrix[j, i]);

                newCurrWay = new List<String>(currWay);
                newCurrWay.Add("up");
                RecSeeker(j - 1, i, newCurrWay, matrix, currentPrice + matrix[j, i]);

                newCurrWay = new List<String>(currWay);
                newCurrWay.Add("left");
                RecSeeker(j, i - 1, newCurrWay, matrix, currentPrice + matrix[j, i]);
            }
        }
    }

    public static void MemoFill() 
    {
        for (int j = 0; j < jMax; j++)
        {
            for (int i = 0; i < iMax; i++)
            {
                memoTable[j, i] = int.MaxValue;
            }
        }
    }

    public static int[,] GetRandomMatrix(int N)
    {
        int[,] m = new int[N, N];

        Random r = new Random();

        for (int j = 0; j < N; j++)
        {
            for (int i = 0; i < N; i++)
            {
                m[j, i] = r.Next(0, N * N + 1);
            }
        }

        return m;
    }
}