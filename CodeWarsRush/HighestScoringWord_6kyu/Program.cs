public class HighestScoringWord 
{
    public static Dictionary<char, int> scoresLibrary;

    static void Main(string[] args)
    {
        // Console.WriteLine((char) 97);

        Console.WriteLine(High("what time are we climbing up to the volcano"));
    }

    public static string High(string s)
    {
        int maxScores = 0; // initial values
        string maxScoresWord = "";

        scoresLibrary = new Dictionary<char, int>();

        for (int i = 0; i < 26; i ++) 
        {
            scoresLibrary.Add((char) (97 + i), i + 1);
        }

        string[] strs = s.Split(" ");

        foreach (var str in strs)
        {
            int currWordScores = 0;

            foreach (var symbol in str) {

                currWordScores += scoresLibrary[symbol];
            }

            if (currWordScores > maxScores) 
            {
                maxScores = currWordScores;

                maxScoresWord = str;
            }
        }

        return maxScoresWord;
    }
}