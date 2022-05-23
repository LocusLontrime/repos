using System.Text;
public class ParasiticNumbersN // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(CalculateSpecial(3, 36));
    }

    public static string CalculateSpecial(int trailingDigit, int numberBase)
    {
        int digit = trailingDigit, aux = 0;

        StringBuilder parasiticOne = new StringBuilder(GetBasedDig(trailingDigit));

        while (true)
        { 
            int currMultiplication = digit * trailingDigit + aux;  
            
            digit = currMultiplication % numberBase;
            aux = currMultiplication / numberBase;
           
            parasiticOne = new StringBuilder(GetBasedDig(digit)).Append(parasiticOne);

            if (digit == 1 && aux == 0) break;
        }

        return parasiticOne.ToString();
    }

    public static string GetBasedDig(int digit) // representation of a dig
    {
        if (digit < 10)  return digit.ToString();     
        else return ((char)('A' + digit - 10)).ToString();
    }
}