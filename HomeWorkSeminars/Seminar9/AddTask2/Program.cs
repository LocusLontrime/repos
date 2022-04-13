public class AddTask2 // Известно, что пароль длиной 3 символа состоит из латинских букв строчного регистра и цифр от 0 до 9.
                      // Напишите рекурсивный метод, который перебирает все комбинации паролей
{
    public static string letters = "abcdefghijklmnopqrstuvwxyz";
    public static string numbers = "0123456789";
    public static int counterRec;

    public static List<string> list = new List<string>();

    static void Main(string[] args)
    {
        list.Add(letters);
        list.Add(numbers);

        counterRec = 0;

        PrintAllCombinations(5, ""); // method call
        Console.WriteLine($"Recursion has been invoked {counterRec} times"); // operations quantity
    }

    public static void PrintAllCombinations(int length, string str) 
    {
        counterRec++; // counting all the steps

        if (str.Length == length) // border case
        {
            Console.WriteLine(str);
            return;
        }

        foreach (var item in list) // cycling all over the dictionaries        
            foreach (var character in item) // cycling all over the characters in the current dictionary           
                PrintAllCombinations(length, str + character); // recursive call                   
    }
}