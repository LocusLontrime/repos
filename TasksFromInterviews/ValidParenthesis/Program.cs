using System.Text;

public class ValidParentheses
{
    public static List<String> parenthesisList = new List<String>();

    static void Main(string[] args)
    {
        int N = 6;

        for (int i = 1; i <= N; i++) 
        {
            ValidParenthesisRecSeeker(0, 0, i, new StringBuilder(""), parenthesisList);

            Console.WriteLine($"2*{i} valid parenthesis variations:\n");

            foreach (var item in parenthesisList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nParenthesis quantity: {parenthesisList.Count}\n"); 

            parenthesisList.Clear();
        }
    }

    public static void ValidParenthesisRecSeeker(int openCount, int closeCount, int maxCount, StringBuilder currentParenthesis, 
        List<String> parenthesisList) 
    {
        if (currentParenthesis.Length == 2 * maxCount) 
        {     
            // adding a valid parenthesis to a result list
            parenthesisList.Add(currentParenthesis.ToString());           
        }
      
        if (openCount < maxCount) 
        {
            // appending a new symbol
            currentParenthesis.Append('(');
            // next rec call
            ValidParenthesisRecSeeker(openCount + 1, closeCount, maxCount, currentParenthesis, parenthesisList);
            // bactracking
            currentParenthesis.Remove(currentParenthesis.Length - 1, 1);
        }

        if (closeCount < openCount)
        {
            // appending a new symbol
            currentParenthesis.Append(')');
            // next rec call
            ValidParenthesisRecSeeker(openCount, closeCount + 1, maxCount, currentParenthesis, parenthesisList);
            // bactracking
            currentParenthesis.Remove(currentParenthesis.Length - 1, 1); // ??? interesting part of rec
        }
    }
}