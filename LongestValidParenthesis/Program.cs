public class LongestValidParentheses { // accepted (speed: 48ms, incredibly fast, beats 100% of C# submissions) //

    static void Main(string[] args)
    {
        Console.WriteLine(longestValidParentheses(")))(()()()()())))()()"));
    }

    public static int longestValidParentheses(string s) { // counting linear (O(n) runtime) method with O(1) extra space

        int countLeft = 0, countRight = 0;
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++) // 1 phase, from left to right
        { 
            if (s[i].Equals('('))
            {
                countLeft++; 
            }
            else 
            { 
                countRight++;
            }

            if (countLeft == countRight) maxLength = Math.Max(maxLength, 2 * countLeft); // when the left parenthesis count equals to the right one we compare
                                                                                         // the length of the current valid parenthesis with the maxLength and rewrite maxLength
                                                                                         // if it is less than currentLength (equals 2* countLeft)
            else if (countRight >= countLeft) { // if cR != cL -> we nullify both counters and start over new
                countLeft = 0;
                countRight = 0;
            }
        }

        countLeft = 0; // we nullify both counters before the way back
        countRight = 0;
   
        for (int i = s.Length - 1; i >= 0; i--) // 2 phase, from right to left
        {
            if (s[i].Equals(')'))
            {
                countRight++;
            }
            else 
            {
                countLeft++;
            }

            if (countLeft == countRight) maxLength = Math.Max(maxLength, 2 * countLeft); // like it was before
            else if (countRight <= countLeft)
            {
                countLeft = 0;
                countRight = 0;
            }

        }
        return maxLength;
    }
}