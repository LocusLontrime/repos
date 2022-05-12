public class SudokuSolutionValidator // accepted on codewars.com
{
    static void Main(string[] args)
    {

        int[,] sudoku = new int[,] 
        {
            { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
            { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
            { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
            { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
            { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
            { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
            { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
            { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
        };

        Console.WriteLine(IsSudokuValid(sudoku));
    }

    public static bool IsSudokuValid(int[,] board) // checks if there is any repeating numbers in row/column or square 3*3
    {
        bool flag = true;
        int symbol;
        int counter_of_points = 0;

        HashSet<int> chars = new HashSet<int>(); // hash table for symbols

        //Rows

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                symbol = board[i, j];
                if (symbol != 0) chars.Add(symbol);
                else counter_of_points++;
            }
            if (chars.Count + counter_of_points != 9) return false;
            chars.Clear();
            counter_of_points = 0;
        }

        //Columns

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                symbol = board[j, i];
                if (symbol != 0) chars.Add(symbol);
                else counter_of_points++;
            }
            if (chars.Count + counter_of_points != 9) return false;
            chars.Clear();
            counter_of_points = 0;
        }

        //Squares 3x3...

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                symbol = board[3 * (i / 3) + j / 3, 3 * (i % 3) + j % 3];
                if (symbol != 0) chars.Add(symbol);
                else counter_of_points++;
            }
            if (chars.Count + counter_of_points != 9) return false;
            chars.Clear();
            counter_of_points = 0;
        }

        return flag; // is Sudoku board valid?
    }
}