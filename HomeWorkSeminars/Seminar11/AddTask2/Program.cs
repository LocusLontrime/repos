public class AdddTask2 // Шахматный конь стоит на поле с координатами (x1, y1).
                       // Сколько ходов ему потребуется сделать, чтобы забрать
                       // неподвижную фигуру на поле (x2, y2)
                       // The horse pronlem...)
{
    public static int[,] memoTable; // memo table for the recursion
    public static int recCounter; // how many times the recursion has been invoked
    public static int maxSteps;

    static void Main(string[] args)
    {       
        Console.WriteLine("Max steps: " + StartRec()); // an extended method call

        Console.WriteLine();

        Console.WriteLine("Min steps: " + MinStepsToCell(3, 4, 5, 7) + "\n"); // addTask2 method call
        MemoPrint();
    }

    public static int StartRec() // searches the max steps needed for the Knight starting at
                                                       // the random place to beat a random located Chess-figure
    {
        memoTable = new int[8, 8];
        maxSteps = 0;
        recCounter = 0;

        for (int j = 0; j < memoTable.GetLength(0); j++) // cycling all over the chess field cells
        {
            for (int i = 0; i < memoTable.GetLength(1); i++)
            {
                MemoInit(); // initialization of the memoTable              
                RecSeeker(j, i, 0); // recursion call
                maxSteps = Math.Max(maxSteps, MaxElementInMemoTable()); // calculating maxSteps 
            }
        }

        Console.WriteLine("StartRec rec count: " + recCounter);

        return maxSteps;
    }

    public static int MinStepsToCell(int startJ, int startI, int endJ, int endI) // Method for the AddTask2 -> calcs min steps needed for the Knight
                                                                                 // to reaches the cell (endJ, endI) from the cell (startJ, startI);
    {
        memoTable = new int[8, 8];
        recCounter = 0;

        MemoInit(); // initialization of the memoTable

        RecSeeker(startJ, startI, 0); // recursion call

        Console.WriteLine("MinSteps rec count: " + recCounter); 

        return memoTable[endJ, endI]; // returning the resulting value (min steps)
    }

    public static void RecSeeker(int j, int i, int stepsCount) // recursive seeker for building the memoTable of steps needed for the Knight
                                                               // located at the current position
                                                               // to reach the every cell at the Chess-field
    {
        recCounter++;

        if (IsCoordsValid(j, i) && stepsCount < memoTable[j, i])
        {
            memoTable[j, i] = stepsCount; // here we fill thr memoTable or change the value if it is needed

            RecSeeker(j - 2, i - 1, stepsCount + 1); // further rec calls
            RecSeeker(j - 2, i + 1, stepsCount + 1);
            RecSeeker(j - 1, i - 2, stepsCount + 1);
            RecSeeker(j - 1, i + 2, stepsCount + 1);
            RecSeeker(j + 1, i - 2, stepsCount + 1);
            RecSeeker(j + 1, i + 2, stepsCount + 1);
            RecSeeker(j + 2, i - 1, stepsCount + 1);
            RecSeeker(j + 2, i + 1, stepsCount + 1);
        }
    }

    public static int MaxElementInMemoTable() // here we search for the max element in the memoTable
    {
        int maxElement = int.MinValue;

        for (int j = 0; j < memoTable.GetLength(0); j++)
        {
            for (int i = 0; i < memoTable.GetLength(1); i++)
            {
                maxElement = Math.Max(maxElement, memoTable[j, i]);
            }
        }

        return maxElement;
    }

    public static void MemoInit() // initialization of thr memoTable with int.MinValue 
    {
        for (int j = 0; j < memoTable.GetLength(0); j++)
        {
            for (int i = 0; i < memoTable.GetLength(1); i++)
            {
                memoTable[j, i] = int.MaxValue;
            }
        }
    }

    public static void MemoPrint() // just printing
    {
        for (int j = 0; j < memoTable.GetLength(0); j++)
        {
            for (int i = 0; i < memoTable.GetLength(1); i++)
            {
                Console.Write(memoTable[j, i] + " ");
            }

            Console.WriteLine();
        }
    }

    // checks if the cell is Valid
    public static bool IsCoordsValid(int j, int i) => j >= 0 && i >= 0 && j < memoTable.GetLength(0) && i < memoTable.GetLength(1); 
}