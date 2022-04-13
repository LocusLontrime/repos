using System.Text;

public class TowerOfHanoi
{

    static void Main(string[] args) // 13123213212313
    {
        PrintHanoiSeqRec("1", "2", "3", 3); // test case

        Console.WriteLine(BuildHanoiSeqRec("1", "2", "3", 3).ToString());

        // Console.WriteLine("\nOverall operations quanity: " + (Math.Pow(2, 3) - 1));
    }

    public static void PrintHanoiSeqRec(string left, string middle, string right, int depth) 
    {
        // border case
        if (depth == 0) return; // eventually we run out of discs...

        // first rec call
        PrintHanoiSeqRec(left, right, middle, depth - 1); // at first we relieve the lower disc in the left tower of remained ones

        // do phase
        Console.WriteLine($"Upper disc migration: {left} -> {right}"); // then we move the largest disc from the left area to the right one

        // second rec call
        PrintHanoiSeqRec(middle, left, right, depth - 1); // finally we build the right tower, all we need is to move
                                                          // the remained part of the tower from the middle area to the right one
    }

    // one (a bit long) string solution...
    public static StringBuilder BuildHanoiSeqRec(string left, string middle, string right, int depth) => depth != 0 ? BuildHanoiSeqRec(left, right, middle, depth - 1).Append($"{left}->{right} ").Append(BuildHanoiSeqRec(middle, left, right, depth - 1)) : new StringBuilder("");   
}