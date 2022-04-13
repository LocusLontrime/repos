using System.Text;

public class Task2 // Дана монотонная последовательность, в которой каждое натуральное число n встречается ровно n раз:
                   // 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, ... Дано число m. Выведите первые m членов этой последовательности
{

    static void Main(string[] args)
    {
        Console.WriteLine(RecPrintMonotonousSeq(0, 1, 9450).ToString());

        RecPrintMonotonousSeqVoid(0, 1, 13500, "");
    }

    public static StringBuilder RecPrintMonotonousSeq(int currIndex, int currMaxInex, int count) // max count is equal approx to 9450
    {
        if (count == 0) return new StringBuilder("");

        return currIndex < currMaxInex ? new StringBuilder(currMaxInex + " ").Append(RecPrintMonotonousSeq(++currIndex, currMaxInex, --count)): RecPrintMonotonousSeq(0, ++currMaxInex, count);      
    }

    public static void RecPrintMonotonousSeqVoid(int currIndex, int currMaxInex, int count, string result) // max count is equal approx to 13500
    {
        if (count == 0)
        {
            Console.WriteLine(result);
            return;
        }

        if (currIndex < currMaxInex) RecPrintMonotonousSeqVoid(++currIndex, currMaxInex, --count, result + currMaxInex + " ");
        else RecPrintMonotonousSeqVoid(0, ++currMaxInex, count, result);
    }
}