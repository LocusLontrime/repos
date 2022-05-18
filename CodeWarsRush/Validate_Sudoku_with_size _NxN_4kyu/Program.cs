public class Sudoku // accepted on codewars.com
{
    public int[][] grid; // sudoku board
    public int jMax, iMax;

    public int BOARD_SIZE;
    public int sqrtBoardSize;

    static void Main(string[] args)
    {
        int[][] board = new int[][]
        {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3, 4 },
            new int[] { 1 }
        };

        Sudoku sudoku = new Sudoku(board);

        Console.WriteLine(sudoku.IsValid());
    }

    public Sudoku(int[][] sudokuData)
    {
        //Constructor here

        this.grid = sudokuData;

        jMax = sudokuData.Length;
        iMax = sudokuData[0].Length;
    }   

    public bool IsValid() // general check on validity
    {
        if (jMax != iMax) return false;

        for (int j = 0; j < BOARD_SIZE; j++) // if arrays of arrays is non-rectangle
        {
            if (grid[j].Length != BOARD_SIZE) return false;
        }

        int sqrt = (int)Math.Sqrt(jMax); // as jMax == iMax now we can check only one of them

        if (sqrt * sqrt != jMax) return false; // if the board has incorrect size
        else 
        {
            BOARD_SIZE = jMax;
            sqrtBoardSize = sqrt; 
        }       

        for (int i = 0; i < BOARD_SIZE; i++) // checking for numbers range in sudoku boards
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {               
                if (grid[j][i] < 1 || grid[j][i] > BOARD_SIZE) return false;             
            }
        }

        return IsSudokuValidRepeats(); // next validation method call
    }

    public bool IsSudokuValidRepeats() // checks if there is any repeating numbers in row/column or square 3*3
    {
        int number;       

        HashSet<int> chars = new HashSet<int>(); // hash table for symbols

        //Rows

        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                number = grid[i][j];
                chars.Add(number);
                
            }

            if (chars.Count != BOARD_SIZE) return false;
            chars.Clear();           
        }

        //Columns

        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                number = grid[j][i];
                chars.Add(number);
            }

            if (chars.Count != BOARD_SIZE) return false;
            chars.Clear();           
        }

        //Squares 3x3...

        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                number = grid[sqrtBoardSize * (i / sqrtBoardSize) + j / sqrtBoardSize]
                    [sqrtBoardSize * (i % sqrtBoardSize) + j % sqrtBoardSize];
                chars.Add(number);
            }

            if (chars.Count != BOARD_SIZE) return false;
            chars.Clear();         
        }

        return true; // is Sudoku board valid?
    }
}