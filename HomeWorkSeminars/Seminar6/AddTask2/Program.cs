public class AddTask2 // На вход подаётся поговорка “без труда не выловишь и рыбку из пруда”.
                      // Используя рекурсию, подсчитайте, сколько в поговорке гласных букв
{
    public static string dict = "аеёиоуыэюя";

    static void Main(string[] args)
    {
        Console.WriteLine(VowelsCount("без труда не выловишь и рыбку из пруда", 0));
    }

    public static int VowelsCount(string s, int i) 
    {
        // base case
        if (i == s.Length) return 0; 

        //vowels checking
        foreach (var item in dict) 
        {
            // return if the current char is a vowel (incrementation of the vowels counter)
            if (item == s[i]) return VowelsCount(s, i + 1) + 1;
        }

        // return if the current char is not a vowel (the vowels counter remains the same)
        return VowelsCount(s, i + 1);
    }
}