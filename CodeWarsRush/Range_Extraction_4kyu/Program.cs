using System.Text;

public class RangeExtraction // accepted on codewars.com
{
    static void Main(string[] args)
    {
        int[] array = new int[] { -10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20, 23 };

        array = new int[] { 9, 101, 102, 103, 105, 106, 108, 110, 112, 114, 116, 118, 119, 120, 121, 122, 123, 125, 127, 129, 131 };

        array = new int[] { 1, 2, 3, 6, 7 };

        Console.WriteLine(Extract(array));
    }

    public static string Extract(int[] args)
    {
        StringBuilder str = new StringBuilder("");

        int i = 0;
        int currSeqCounter = 0;

        while (i < args.Length - 1) 
        {
            currSeqCounter = 0;

            while (i < args.Length - 1 && args[i] + 1 == args[i + 1])
            {
                i++;
                currSeqCounter++;
            }

            if (currSeqCounter > 1)
            {
                str.Append(args[i] - currSeqCounter).Append("-").Append(args[i]).Append(",");
            }
            else if (currSeqCounter == 1) 
            {
                str.Append(args[i - 1]).Append(",").Append(args[i]).Append(",");
            }


            while (i < args.Length - 1 && args[i] + 1 != args[i + 1]) 
            {               
                if(i == 0 || i > 0 && args[i - 1] + 1 != args[i]) str.Append(args[i]).Append(",");
                i++;
            }
        }
        
        if (args[args.Length - 1 - 1] + 1 != args[args.Length - 1]) str.Append(args[i]).Append(",");
       
        str.Remove(str.Length - 1, 1);

        return str.ToString();  //TODO
    }
}