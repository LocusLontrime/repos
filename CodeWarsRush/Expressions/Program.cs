using System.Diagnostics;

public class Expressions 
{
    public static int counter;
    public static int sols;

    static void Main(string[] args)
    {
        int n = 1000;
        int digit = 8;
        int length = 8;

        Stopwatch sw = new Stopwatch();

        sw.Start();

        counter = 0;
        sols = 0;

        // RecSeeker(n, digit, length, 0, 0, "");

        Console.WriteLine($"Counter: {counter}, sols: {sols}");

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        sw.Start();

        counter = 0;
        sols = 0;

        RecSeekerNonPar(n, digit, length, 0, 0, "", 0, "");

        Console.WriteLine($"Counter: {counter}, sols: {sols}");

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        sw.Start();

        counter = 0;
        sols = 0;

        // RecSeekerAux(n, digit, length, 0, 0, "", 0, "");

        Console.WriteLine($"Counter: {counter}, sols: {sols}");

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");

        Console.WriteLine(GetNumber(5, 8));
    }

    public static void RecSeekerAux(int aim, int digit, int length, int digitsUsed, int currSum, string expression, int currParSum, string currParExp) 
    {
        counter++;

        if (digitsUsed == length && currParExp.Length == 0) 
        {
            if (currSum == aim)
            {
                sols++;
                Console.WriteLine(expression);
            }
            else
            {
                // Console.WriteLine("invalid: " + expression);
                return;
            }
        }

        for (int i = 1; i <= length - digitsUsed; i++) 
        {
            if (currParExp.Length == 0)
            {
                //continue building the main path
                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum + GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : expression + $" + {GetNumber(i, digit)}", currParSum, currParExp);

                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum - GetNumber(i, digit), digitsUsed == 0 ? $"-{GetNumber(i, digit)}" : expression + $" - {GetNumber(i, digit)}", currParSum, currParExp);

                if (digitsUsed != 0) RecSeekerAux(aim, digit, length, digitsUsed + i, currSum * GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : "(" + expression + ")" + $" * {GetNumber(i, digit)}", currParSum, currParExp);

                if (digitsUsed != 0 && currSum % GetNumber(i, digit) == 0) RecSeekerAux(aim, digit, length, digitsUsed + i, currSum / GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : "(" + expression + ")" + $" / {GetNumber(i, digit)}", currParSum, currParExp);

                //here we begin to build a nested perenthesis
                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum, expression, currParSum + GetNumber(i, digit), currParExp + $"{GetNumber(i, digit)}");

                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum, expression, currParSum - GetNumber(i, digit), currParExp + $"-{GetNumber(i, digit)}");
            }
            else 
            {
                // continue building a nested perenthesis
                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum, expression, currParSum + GetNumber(i, digit), currParExp + $" + {GetNumber(i, digit)}");

                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum, expression, currParSum - GetNumber(i, digit), currParExp + $" - {GetNumber(i, digit)}");

                RecSeekerAux(aim, digit, length, digitsUsed + i, currSum, expression, currParSum + GetNumber(i, digit), "(" + currParExp + ")" + $" * {GetNumber(i, digit)}");

                if (currParSum % GetNumber(i, digit) == 0) RecSeekerAux(aim, digit, length, digitsUsed + i, currSum, expression, currParSum / GetNumber(i, digit), "(" + currParExp + ")" + $" / {GetNumber(i, digit)}");              
            }
        }

        if (expression.Length != 0 && currParExp.Length != 0) 
        {
            // adding a nested perenthesis to the main path
            RecSeekerAux(aim, digit, length, digitsUsed, currSum * currParSum, $"({expression}) * ({currParExp})", 0, ""); 

            if (currParSum != 0 && currSum % currParSum == 0) RecSeekerAux(aim, digit, length, digitsUsed, currSum * currParSum, $"({expression}) / ({currParExp})", 0, "");
        }
    }

    public static void RecSeekerNonPar(int aim, int digit, int length, int digitsUsed, int currSum, string expression, int currParSum, string currParExp)
    {
        counter++;

        if (digitsUsed == length && currParExp.Length == 0)
        {
            if (currSum == aim)
            {
                sols++;
                Console.WriteLine(expression);
            }
            else
            {
                // Console.WriteLine("invalid: " + expression);
                return;
            }
        }

        for (int i = 1; i <= length - digitsUsed; i++)
        {
            if (currParExp.Length == 0)
            {
                //continue building the main path
                RecSeekerNonPar(aim, digit, length, digitsUsed + i, currSum + GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : expression + $" + {GetNumber(i, digit)}", currParSum, currParExp);

                RecSeekerNonPar(aim, digit, length, digitsUsed + i, currSum - GetNumber(i, digit), digitsUsed == 0 ? $"-{GetNumber(i, digit)}" : expression + $" - {GetNumber(i, digit)}", currParSum, currParExp);

                //here we begin to build a nested perenthesis
                RecSeekerNonPar(aim, digit, length, digitsUsed + i, currSum, expression, currParSum + GetNumber(i, digit), currParExp + $"{GetNumber(i, digit)}");

                // RecSeekerNonPar(aim, digit, length, digitsUsed + i, currSum, expression, currParSum - GetNumber(i, digit), currParExp + $"-{GetNumber(i, digit)}");
            }
            else
            {
                RecSeekerNonPar(aim, digit, length, digitsUsed + i, currSum, expression, currParSum * GetNumber(i, digit), currParExp + $"*{GetNumber(i, digit)}");

                if (currParSum % GetNumber(i, digit) == 0) RecSeekerNonPar(aim, digit, length, digitsUsed + i, currSum, expression, currParSum / GetNumber(i, digit), currParExp + $"/{GetNumber(i, digit)}");
            }
        }

        if (currParExp.Length != 0)
        {
            // adding a nested perenthesis to the main path
            RecSeekerNonPar(aim, digit, length, digitsUsed, currSum + currParSum, expression.Length == 0 ? $"{currParExp}" : $"{expression} + {currParExp}", 0, "");

            RecSeekerNonPar(aim, digit, length, digitsUsed, currSum - currParSum, expression.Length == 0 ? $"-{currParExp}" : $"{expression} - {currParExp}", 0, "");
        }
    }

        public static void RecSeeker(int aim, int digit, int length, int digitsUsed, int currSum, string expression)
    {
        counter++;

        if (digitsUsed == length)
        {
            if (currSum == aim)
            {
                sols++;
                Console.WriteLine(expression);
            }
            else return;
        }

        for (int i = 1; i <= length - digitsUsed; i++)
        {
            RecSeeker(aim, digit, length, digitsUsed + i, currSum + GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : expression + $" + {GetNumber(i, digit)}");

            RecSeeker(aim, digit, length, digitsUsed + i, currSum - GetNumber(i, digit), digitsUsed == 0 ? $"-{GetNumber(i, digit)}" : expression + $" - {GetNumber(i, digit)}");

            if (digitsUsed != 0) RecSeeker(aim, digit, length, digitsUsed + i, currSum * GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : "(" + expression + ")" + $" * {GetNumber(i, digit)}");

            if (digitsUsed != 0 && currSum % GetNumber(i, digit) == 0) RecSeeker(aim, digit, length, digitsUsed + i, currSum / GetNumber(i, digit), digitsUsed == 0 ? $"{GetNumber(i, digit)}" : "(" + expression + ")" + $" / {GetNumber(i, digit)}");
        }
    }

    public static int GetNumber(int length, int digit) 
    {
        int number = 0;

        for (int i = 0; i < length; i++)
        {
            number *= 10;
            number += digit;
        }

        return number;
    }
}