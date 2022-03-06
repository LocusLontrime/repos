using System.Text;
public class Task70 {

    public static void Main(String[] args)
    {
        int number = 1236789989;
        StringBuilder sb = new StringBuilder("");

        Console.WriteLine("Sum = " + recursiveSeeker(number, sb));

        Console.WriteLine(sb);
    }

    public static int recursiveSeeker(int num, StringBuilder sb) { // print digits and calculating sum

        if (num == 0) return 0;

        int rem = num % 10;

        sb.Insert(0, rem + " ");

        return rem + recursiveSeeker(num / 10, sb);
    }
}