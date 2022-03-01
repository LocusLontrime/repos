public class Sem1Task9 { // Найти третью цифру числа или сообщить, что её нет

    public static void Main(string[] args) // solution without MAth lib and SomeString.Length method
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());

        if (number < 100) Console.WriteLine("The number given has no third digit"); // checking
        else {
            int length = 0;
            int tempNum = number;

            while (tempNum > 0) // calculates the number's length
            {
                tempNum /= 10;
                length++;
            }

            for (int i = 0; i < length - 3; i++) // finds the third digit
            {
                number /= 10;
            }

            Console.WriteLine("The third digit of the number given is: " + number % 10); 
        }
    }
}