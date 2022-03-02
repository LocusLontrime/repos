public class Sem1Task9 { // Найти третью цифру числа или сообщить, что её нет

    public static void Main(string[] args) //Показать третью слева цифру числа, solution without Math lib and SomeString.Length method
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine());

        if (number < 100) Console.WriteLine("The number given has no third digit"); // checking
        else {
            
            while (number >= 1000) // calculates the number's length
            {
                number /= 10;              
            }         

            Console.WriteLine("The third digit of the number given is: " + number % 10); 
        }
    }
}