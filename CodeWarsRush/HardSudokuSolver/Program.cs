using System.Diagnostics;

public class HardSudokuSolver // 2KYU, not accepted on codewars, coz too slow
{
    // Here we will be storing the information about placed numbers. According to the Sudoku-game rules,
    // We need to keep sets of rows, columns and squares so that the numbers do not repeat in these sets.
    // Thus, we should implement three 2D-arrays: rows, columns and squares

    public static int[,] rows = new int[9, 9];    // to keep the info about numbers used in the every row of the board given
    public static int[,] columns = new int[9, 9]; // to keep the info about numbers used in the every column of the board given
    public static int[,] squares = new int[9, 9]; // to keep the info about numbers used in the every square of the board given

    public static char[,] board; // storing the board given

    public static char[,] solution;

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

        board = new char[,] // from test of codewars.com
        {
            {'.', '.', '6', '1', '.', '.', '.', '.', '8'},
            {'.', '8', '.', '.', '9', '.', '.', '3', '.'},
            {'2', '.', '.', '.', '.', '5', '4', '.', '.'},
            {'4', '.', '.', '.', '.', '1', '8', '.', '.'},
            {'.', '3', '.', '.', '7', '.', '.', '4', '.'},
            {'.', '.', '7', '9', '.', '.', '.', '.', '3'},
            {'.', '.', '8', '4', '.', '.', '.', '.', '6'},
            {'.', '2', '.', '.', '5', '.', '.', '8', '.'},
            {'1', '.', '.', '.', '.', '2', '5', '.', '.'},
        };

        Stopwatch sw = new Stopwatch();

        sw.Start();

        SolveSudoku(board); // the main method call

        sw.Stop();       

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms" + " solCounter = " + solutionsCounter);

        Console.WriteLine("\nMax operations' number using backtracking: " + Math.Pow(1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9, 9));
        Console.WriteLine("\nMax operations' number using bruteForce: " + Math.Pow(9, 81));
    }

    public static void SolveSudoku(char[,] board) // the main method that starts backtracking and placement of numbers into the board
    {
        if (!IsSudokuValid(board)) 
        {
            throw new ArgumentException(); 
        }

        isSolved = false;

        HardSudokuSolver.board = board;

        for (int j = 0; j < boardSize; j++)
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (board[j, i] != '.') PlaceNumber((int)Char.GetNumericValue(board[j, i]), j, i); // adds every number on board to the sets
            }
        }

        RecursiveSeeker(0, 0); // starts recursion

        if (!isSolved || solutionsCounter != 1)
        {
            throw new ArgumentException();
        }
        
        PrintSudoku(solution); // the solution if exists and is unique       
    }

    public static void PlaceNumber(int number, int j, int i) // adds a number to the sets and on the board in the point of: board(j , i)
    {
        int indexSquare = squareSize * (j / squareSize) + i / squareSize; // index of Sudoku-Square

        rows[j, number - 1] = 1;
        columns[i, number - 1] = 1;
        squares[indexSquare, number - 1] = 1;
        board[j, i] = (char)(number + '0');
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
                    if (solutionsCounter <= 1) DeleteNumber(num, j, i); // a step of bactracking                   
                }
            }
        } // if not, then we're making a new step
        else PlaceNext(j, i);
    }

    public static void PlaceNext(int j, int i) // a new step of backtracking   
    {
        if (j == boardSize - 1 && i == boardSize - 1) // if Sudoku is solved
        {
            solutionsCounter++;
            solution = (char[,]) board.Clone(); // making a copy
            isSolved = true;
        }
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

    public static bool IsSudokuValid(char[,] board) // general check on validity
    {
        if (board.GetLength(0) != 9 || board.GetLength(1) != 9) return false; // if the board has incorrect size

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[j, i] != '.')
                {
                    if (Char.GetNumericValue(board[j, i]) < 1 || Char.GetNumericValue(board[j, i]) > 9) return false;
                }
            }
        }

        return IsSudokuValidRepeats(board); // next validation method call
    }

    public static bool IsSudokuValidRepeats(char[,] board) // checks if there is any repeating numbers in row/column or square 3*3
    {
        char symbol;
        int counter_of_points = 0;

        HashSet<char> chars = new HashSet<char>(); // hash table for symbols

        //Rows

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                symbol = board[i, j];
                if (symbol != '.') chars.Add(symbol);
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
                if (symbol != '.') chars.Add(symbol);
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
                if (symbol != '.') chars.Add(symbol);
                else counter_of_points++;
            }
            if (chars.Count + counter_of_points != 9) return false;
            chars.Clear();
            counter_of_points = 0;
        }

        return true; // is Sudoku board valid?
    }
}