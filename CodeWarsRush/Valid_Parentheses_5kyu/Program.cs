public class ValidParentheses 
{

    static void Main(string[] args)
    {
        Console.WriteLine(IsParenthesesValid("(()())()"));
    }

    public static bool IsParenthesesValid(string input)
    {
        int lCounter = 0, rCounter = 0;

        foreach(var item in input) 
        {
            if (item.Equals('('))
            {
                lCounter++;
            }
            else if(item.Equals(')'))
            { 
                rCounter++;
            }
            else return false;

            if(rCounter > lCounter) return false;
        }

        return lCounter == rCounter;
    }

    public static bool IsParenthesisValid(string s)
    {
        int counter1 = 0;
        int counter2 = 0;

        foreach (char c in s)
        {
            if (c == '(') counter1++;
            else if (c == ')') counter2++;

            if (counter1 - counter2 < 0) return false;
        }

        if (counter1 - counter2 != 0) return false;

        return true;
    }
}
