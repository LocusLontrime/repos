using System.Text;
public class AddTask6 // На вход подаётся число n > 4, указывающее длину пароля.
                                                      // Создайте метод, генерирующий пароль заданной длины.В пароле
                                                      // обязательно использовать цифру, букву и специальный знак
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a password length");
        int length = int.Parse(Console.ReadLine());
        Console.WriteLine("Password: " + GeneratePassword(length));
    }

    public static string GeneratePassword(int length) 
    {

        string[] array = new string[]  { "АБВГДЕЖЗИКЛМНОПРСТУФХЧШЭЮЯ", "абвгдежзиклмнопрстуфхчшэюя", "0123456789", "!\"#$%&\\'()*+,-./:;<=>?@[\\\\]^_`{|}~" };

        int nmbrs = length / 4; // here we define the number of max elements available for every group
        int specSmbls = length / 4;
        int upCsLttrs = (length - nmbrs - specSmbls) / 2;
        int downCsLttrs = length - nmbrs - specSmbls - upCsLttrs;
        int [] lengths = new int[] { nmbrs, specSmbls, upCsLttrs, downCsLttrs }; // array with numbers of max elements available for every group

        StringBuilder s = new StringBuilder("");
        Random random = new Random();
        // int counter = 0;

        for (int i = 0; i < length; i++) // cycling all over the password's cells
        {
            while (true) // cycling unless the new character finds its place
            {
                int p = random.Next(4); // we take a random elements group
                if (lengths[p] == 0) continue; // if we cannot take the element from this group we proceed to the next step of the cycle while
                // counter++;
                int q = random.Next(array[p].Length); // here we take the random element from the group chosen
                lengths[p]--; // decreasing of max number of elements available for the current group of symbols
                s.Append(array[p][q]); // adding symbol to the stringBuilder
                // if (counter == length) break;
                break; // if symbol is added -> break
            }
        }
          
        return s.ToString(); // returning the password built
    }

}