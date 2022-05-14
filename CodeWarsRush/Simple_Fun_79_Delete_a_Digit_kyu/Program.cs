public class SimpleFun79DeleteDigit // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(DeleteDigit(178956));
    }

    public static int DeleteDigit(int num) // covering
    {
        //coding and coding..
        int length = (int)Math.Log10(num) + 1;
        int max = int.MinValue; // for further convenience

        for (int i = 0; i < length; i++)
        {
            int currMax = RecSeeker(num, i, 0);

            max = Math.Max(max, currMax);
        }
        
        return max;
    }

    public static int RecSeeker(int number, int index, int currInd) 
    {
        // border cases
        if (number == 0) return 0;
        if (index == 0) return number / 10;
        
        // body of rec -->> nothing for now

        // reccurent relation
        if(currInd != index - 1) return 10 * RecSeeker(number / 10, index, currInd + 1) + number % 10;
        else return 10 * RecSeeker(number / 100, index, currInd + 2) + number % 10;
    }
}