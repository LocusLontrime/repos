using System.Diagnostics;

public class Boggle
{
    public char[][] board;
    public string word;
    public int jMax, iMax;

    public int recSeeker;

    public static int[][] dirs = { // directions of cell-moving
        new int[] { 0, 1 }, // r
        new int[] { 1, 1 }, // dr
        new int[] { 1, 0 }, // d
        new int[] { 1, -1 }, // dl
        new int[] { 0, -1 }, // l
        new int[] { -1, -1 }, // ul
        new int[] { -1, 0}, // u
        new int[] { -1, 1 } // ur
    };

    static void Main(string[] args)
    {
       char[][] board =
       {
           new []{'E','A','R','A'},
           new []{'N','L','E','C'},
           new []{'I','A','I','S'},
           new []{'B','Y','O','R'}
       };

        string word = "RSCAREIOYBAILNEA";

        Boggle boggle = new Boggle(board, word);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        Console.WriteLine(boggle.Check());
        Console.WriteLine($"recSeeker: {boggle.recSeeker}");
        sw.Stop();
        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        char[][] boardNew = GetRandomBoard(11111, 11111);
        string wordNew = "NGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJS" +
            "VBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJN" +
            "GJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJS" +
            "VBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJN" +
            "GJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJS" +
            "VBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJN" +
            "GJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJS" +
            "VBSDHJNGJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJN" +
            "GJDUIFFLCLVDDSGNSJIBGUSAVMKDVDJSIVYDGVTRDFEYWFJWNCJXNVSHUVTDSAFWFUWIFNDJSVBSDVUGDSTYFEWYFGBFVDJSVBSDHJ";

        Boggle boggleNew = new Boggle(boardNew, wordNew);

        sw.Start();
        Console.WriteLine(boggleNew.Check());
        Console.WriteLine($"recSeeker: {boggleNew.recSeeker}");
        sw.Stop();
        Console.WriteLine("Time elapsed New: " + sw.ElapsedMilliseconds + "ms");

        // PrintBoard(boardNew);
    }


    public Boggle(char[][] board, string word) 
    {
        // Your code here!
        this.board = board;
        this.word = word;

        jMax = board.Length;
        iMax = board[0].Length;

        recSeeker = 0;
    }

    public bool Check()
    {
        // Your code here too!
        for (int j = 0; j < jMax; j++) 
        {
            for (int i = 0; i < iMax; i++)
            {
                if (Dfs(j, i, 0)) return true;
            }          
        }

        return false;
    }

    public bool Dfs(int j, int i, int k) // k -->> current chain length
    {
        recSeeker++;

        // base case
        if (k >= word.Length) return true;

        // dfs body
        if (j < jMax && j >= 0 && i < iMax && i >= 0 && board[j][i] != '*') 
        {
            if (board[j][i] == word[k++]) 
            {
                board[j][i] = '*';              

                //reccurent relation
                for (int dir_index = 0; dir_index < dirs.Length; dir_index++) 
                {
                    if(Dfs(j + dirs[dir_index][0], i + dirs[dir_index][1], k)) return true;
                }           

                board[j][i] = word[--k]; // bactracking               
            }
        }
      
        return false;
    }

    public static char[][] GetRandomBoard(int jMax, int iMax)
    {
        Random random = new Random();

        char[][] board = new char[jMax][];

        for (int i = 0; i < jMax; i++)
        {
            board[i] = new char[iMax];
        }

        for (int j = 0; j < jMax; j++) 
        {
            for (int i = 0; i < iMax; i++)
            {
                board[j][i] = (char)random.Next(65, 91 + 1);
            }
        }

        return board;
    }

    public static void PrintBoard(char[][] board)
    {
        for (int j = 0; j < board.Length; j++)
        {
            for (int i = 0; i < board[0].Length; i++)
            {
                Console.Write(board[j][i] + " ");
            }

            Console.WriteLine();
        }
    }
}