using System.Diagnostics;

public class SudokuSolver37 // accepted (speed: 148ms, very fast, beats 93.12% of C# submissions) 36
{
    // Here we will be storing the information about placed numbers. According to the Sudoku-game rules,
    // We need to keep sets of rows, columns and squares so that the numbers do not repeat in these sets.
    // Thus, we should implement three 2D-arrays: rows, columns and squares

    public static int[,] rows = new int[9, 9];    // to keep the info about numbers used in the every row of the board given
    public static int[,] columns = new int[9, 9]; // to keep the info about numbers used in the every column of the board given
    public static int[,] squares = new int[9, 9]; // to keep the info about numbers used in the every square of the board given

    public static char[,] board; // storing the board given

    public static readonly int boardSize = 9; // size of the board 
    public static readonly int squareSize = 3; // size of mini-squares

    public static bool isSolved; // is Sudoku solved or not

    public static int solutionsCounter; // if > 2 then there are multiple solutions

    public static void Main(string[] args)
    {
        char[,] board = { // some test case
            {'5', '3', '.', '.', '7', '.', '.', '.', '.' },
            {'6', '.', '.', '1', '9', '5', '.', '.', '.' },
            {'.', '9', '8', '.', '.', '.', '.', '6', '.' },
            {'8', '.', '.', '.', '6', '.', '.', '.', '3' },
            {'4', '.', '.', '8', '.', '3', '.', '.', '1' },
            {'7', '.', '.', '.', '2', '.', '.', '.', '6' },
            {'.', '6', '.', '.', '.', '.', '2', '8', '.' },
            {'.', '.', '.', '4', '1', '9', '.', '.', '5' },
            {'.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        board = new char[,] { // -> лёгкий уровень Судоку, тест с ЛитКода
            {'.','.','9','7','4','8','.','.','.'},
            {'7','.','.','.','.','.','.','.','.'},
            {'.','2','.','1','.','9','.','.','.'},
            {'.','.','7','.','.','.','2','4','.'},
            {'.','6','4','.','1','.','5','9','.'},
            {'.','9','8','.','.','.','3','.','.'},
            {'.','.','.','8','.','3','.','2','.'},
            {'.','.','.','.','.','.','.','.','6'},
            {'.','.','.','2','7','5','9','.','.'}
        };

        board = new char[,] { // https://sudoku.com/ru/evil/ -> безумный уровень Судоку 36ms
            {'1', '.', '.', '4', '3', '.', '.', '5', '.' },
            {'.', '.', '5', '.', '.', '.', '9', '.', '.' },
            {'.', '.', '.', '.', '2', '.', '.', '.', '.' },
            {'.', '.', '.', '.', '.', '6', '.', '.', '.' },
            {'.', '8', '.', '.', '.', '.', '.', '.', '7' },
            {'3', '.', '.', '1', '5', '.', '.', '9', '.' }, // (9!) ^ 9
            {'.', '3', '.', '6', '4', '.', '8', '.', '.' },
            {'.', '.', '.', '.', '.', '2', '.', '4', '.' },
            {'6', '.', '.', '.', '.', '9', '.', '.', '.' }
        };

        Stopwatch sw = new Stopwatch();

        sw.Start();

        SolveSudoku(board); // the main method call

        sw.Stop();

        PrintSudoku(board); // print after done

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        Console.WriteLine("\nMax operations' number using backtracking: " + Math.Pow(1*2*3*4*5*6*7*8*9, 9));
        Console.WriteLine("\nMax operations' number using bruteForce: " + Math.Pow(9, 81));
    }

    public static void SolveSudoku(char[,] board) // the main method that starts backtracking and placement of numbers into the board
    {
        isSolved = false;

        SudokuSolver37.board = board;       

        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (board[j, i] != '.') PlaceNumber((int) Char.GetNumericValue(board[j, i]), j, i); // adds every number on board to the sets
            }
        }

        RecursiveSeeker(0, 0); // starts recursion
    }

    public static void PlaceNumber(int number, int j, int i) // adds a number to the sets and on the board in the point of: board(j , i)
    {
        int indexSquare = squareSize * (j / squareSize) + i / squareSize; // index of Sudoku-Square

        rows[j, number - 1] = 1;
        columns[i, number - 1] = 1;
        squares[indexSquare, number - 1] = 1;
        board[j, i] = (char) (number + '0');
    }

    public static void DeleteNumber(int number, int j, int i) // deletes a number from the sets and from the board in the point of: board(j , i)
    {
        int indexSquare = squareSize * (j / squareSize) + i / squareSize; // index of Sudoku-Square

        rows[j, number - 1] = 0;
        columns[i, number - 1] = 0;
        squares[indexSquare, number - 1] = 0;
        board[j, i] = '.';
    }

    public static bool IsNumberValid(int number, int j, int i) // checks could we place a number on board in the point of board(j , i)
                                                               // j refers to ROW whilst i refers to COLUMN
    {
        int indexSquare = squareSize * (j / squareSize) + i / squareSize;

        return rows[j, number - 1] + columns[i, number - 1] + squares[indexSquare, number - 1] == 0;
    }

    public static void RecursiveSeeker(int j, int i) // bactracking
    {
        if (board[j, i] == '.') // if some number has already been placed in this cell
        {
            for (int num = 1; num <= 9; num++)
            {
                if (IsNumberValid(num, j, i)) // if the placement is available
                {
                    PlaceNumber(num, j, i); // placement of a number on board
                    PlaceNext(j, i); // proceeding to the next number
                    if (!isSolved) DeleteNumber(num, j, i); // a step of bactracking                   
                }
            }
        } // if not, then we're making a new step
        else PlaceNext(j, i);
    }

    public static void PlaceNext(int j, int i) // a new step of backtracking   
    {
        if (j == boardSize - 1 && i == boardSize - 1) isSolved = true; // if Sudoku is solved
        else 
        {
            if (i == boardSize - 1) RecursiveSeeker(j + 1, 0); // we are proceeding to the next row
            else RecursiveSeeker(j, i + 1); // just a new step to the right
        }
    }

    public static void PrintSudoku(char[,] board) // just printing of a 2D array of chars
    {
        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write(board[j, i] + " ");
            }
            Console.WriteLine();
        }
    }
}