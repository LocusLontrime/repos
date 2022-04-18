public class AdddTask2 // Шахматный конь стоит на поле с координатами (x1, y1).
                       // Сколько ходов ему потребуется сделать, чтобы забрать
                       // неподвижную фигуру на поле (x2, y2)
                       // The horse pronlem...)
{
    public static int[,] memoTable; // memo table for the recursion
    public static long recCounter; // how many times the recursion has been invoked
    public static int maxSteps;

    public static int jSize, iSize;

    static void Main(string[] args)
    {
        jSize = 36; // Chess-field size
        iSize = 36;

        Console.WriteLine("Max steps: " + StartRec()); // an extended method call

        Console.WriteLine();

        int minSteps = MinStepsToCell(3, 4, 5, 7);

        Console.WriteLine("Min steps: " + minSteps + "\n"); // addTask2 method call
        // MemoPrint();

        int maxSteps = MaxElementInMemoTable(); 

        Print_2D_array(memoTable, maxSteps);
    }

    public static int StartRec() // searches the max steps needed for the Knight starting at
                                                       // the random place to beat a random located Chess-figure
    {
        memoTable = new int[jSize, iSize];
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
        memoTable = new int[jSize, iSize];
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

    public static void Print_2D_array(int[,] array, int maxValue) // enhanced printing method, it prints the array in a more convenient way
    { // auxiliary method for 2D array printing        
        int length = (int)Math.Log10(maxValue) + 1;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                int currentNumberLength = array[i, j] != 0 ? (int)Math.Log10(array[i, j]) + 1 : 1;
                Console.Write(array[i, j]);
                for (int k = 0; k <= length - currentNumberLength; k++) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    // checks if the cell is Valid
    public static bool IsCoordsValid(int j, int i) => j >= 0 && i >= 0 && j < memoTable.GetLength(0) && i < memoTable.GetLength(1); 
}