public class Sem1Task6 { // Дано число из отрезка [10, 99]. Показать наибольшую цифру числа

    public static void Main(string[] args) 
    {
        Console.WriteLine("Enter a number that is greater than or equal to 10 and less than 100");
        int number = int.Parse(Console.ReadLine());
        if (number >= 10 && number < 100)
        {
            Console.WriteLine("The max digit of the number given is: " +
                Sem1Task2.Sem1Task2.max(number % 10, number / 10 % 10)); // invocation of the method from another project 
        }
        else 
        {
            Console.WriteLine("The number is out of range");
        }
    }

}