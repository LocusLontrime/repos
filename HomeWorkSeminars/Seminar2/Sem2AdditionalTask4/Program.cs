public class Sem2AdditionalTask4 // Дано натуральное число, в котором все цифры различны. Определить, какая цифра расположена в нем левее: максимальная или минимальная
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a natural number: ");
        int number = int.Parse(Console.ReadLine());

        if (number <= 0) Console.WriteLine("Enter a natural number");
        else if (number <= 1 && number < 10) Console.WriteLine("max and min digits are the same");
        else
        {
            int i = 0;
            int maxIndex = 0, minIndex = 0;
            int maxDigit = 0, minDigit = 9;

            while (number > 0)
            {
                int currentDigit = number % 10;
                number /= 10;
                if (currentDigit >= maxDigit) // finds the min digit's index
                {
                    maxDigit = currentDigit;
                    maxIndex = i;
                }
                if (currentDigit <= minDigit) // finds the max digit's index
                {
                    minDigit = currentDigit;
                    minIndex = i++; // increment
                }
            }
            // Console.WriteLine("MinIndex = " + minIndex + " MaxIndex = " + maxIndex); // -> index checking

            Console.WriteLine((maxIndex < minIndex ? "min digit " + minDigit : "max digit " + maxDigit) + " located to the left");
        }
    }
}