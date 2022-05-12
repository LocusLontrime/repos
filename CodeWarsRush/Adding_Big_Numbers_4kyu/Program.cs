using System.Text;

public class AddingBigNumbers // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(Add("001001", "0000001000"));
    }

    public static string Add(string a, string b)
    {
        int[] aInt = StringToArray(a); // digits array
        int[] bInt = StringToArray(b);

        int[] sum = new int[Math.Max(aInt.Length, bInt.Length) + 1];

        int temporal = 0;

        for (int i = 0; i < sum.Length; i++)
        {
            int currSum = (aInt.Length - i - 1 >= 0 ? aInt[aInt.Length - i - 1] : 0 ) + (bInt.Length - i - 1 >= 0? bInt[bInt.Length - i - 1] : 0 ) + temporal;

            if (currSum <= 9)
            {
                sum[sum.Length - i - 1] = currSum;
                temporal = 0;
            }
            else 
            {
                sum[sum.Length - i - 1] = currSum % 10;
                temporal = 1;
            }
        }

        StringBuilder s = new StringBuilder("");

        bool flag = true;

        for (int i = 0; i < sum.Length; i++) 
        {
            if (flag && sum[i] == 0) 
            { 
            }
            else
            {
                s.Append(sum[i]);
                flag = false;
            }
        }

        return s.ToString();
    }

    public static int[] StringToArray(string number) 
    { 
        int[] num = new int[number.Length];

        for (int i = 0; i < num.Length; i++) 
        {
            num[i] = (int) Char.GetNumericValue(number[i]);
        }

        return num;
    }
}