public class Search2DMatrixII240 // 36 989
{
    static void Main(string[] args)
    {
        int[][] matrix = new int[5][] { 
            new int[] { 1, 4, 7, 11, 15 }, 
            new int[] { 2, 5, 8, 12, 19 }, 
            new int[] { 3, 6, 9, 16, 22 }, 
            new int[] { 10, 13, 14, 17, 24 },
            new int[] { 18, 21, 23, 26, 30 } 
        };

        int target = 5;

        Console.WriteLine(SearchMatrix(matrix, target));
    }

    public static bool SearchMatrix(int[][] matrix, int target)
    {
        return RecSeeker(matrix.Length - 1, 0, matrix, target);
    }

    public static bool RecSeeker(int j, int i, int[][] matrix, int target)
    {
        if (j < 0 || i >= matrix[0].Length) return false;
        if (matrix[j][i] == target) 
        {
            Console.WriteLine($"The coordinates of target {target} are: ({j}, {i})");
            return true; 
        }
        else if (target < matrix[j][i]) return RecSeeker(j - 1, i, matrix, target);
        else return RecSeeker(j, i + 1, matrix, target);
    }

}
