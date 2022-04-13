public class AddTask1 // Дано предложение. Напишите рекурсивный метод, подсчитывающий количество слов
                      // в данном предложении. Словом считается последовательность символов без пробелов
{
    static void Main(string[] args)
    {
        string seq = "Руслан прямо здесь спит и не подозревает что скоро будет писать код а я роффлить";

        // seq = "Рус толстопуз";

        Console.WriteLine("The words quantity: " + RecursiveCounter(0, seq));

        // Console.WriteLine(seq.Remove(0, 7));
    }

    public static int RecursiveCounter(int index, string seq) 
    {     
        // recursive call
        if (index != seq.Length && seq[index] == ' ') return RecursiveCounter(0, index != seq.Length ? seq.Remove(0, index + 1) : "") + 1; // words counter
        else if (index == seq.Length) return 1; // border case
        else return RecursiveCounter(index + 1, seq); // cycling all over the characters in the current word
    }
}