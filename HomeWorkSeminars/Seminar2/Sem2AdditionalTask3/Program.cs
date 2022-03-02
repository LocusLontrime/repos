public class Sem2AdditionalTask3 // Иван в январе года открыл счет в банке, вложив 1000 руб.
                                 // Через каждый месяц размер вклада увеличивается на 1.5% от имеющейся суммы. Определить размер депозита через n месяцев
{
    static int recursiveCounter = 0;

    static void Main(string[] args)
    {
        int initialValue = 1000; 
        double interestRate = 1.5d;
        Console.WriteLine("Enter a number of months"); // numbers that are greater than 1700 lead to out of range values for double-type
        int monthsNumber = int.Parse(Console.ReadLine()); // wee just need to multiply the initial value by
                                                          // the coefficient raised to the power of n (monthsNumber)
        Console.WriteLine("The final value of deposit equals: " + initialValue * riseToPowerFast(interestRate, monthsNumber));
        Console.WriteLine("The algo did: " + recursiveCounter + " steps"); // to see, how O(log(n)) runtime is effective
    }

    public static double riseToPowerFast(double baseNumber, int power) // fast power-rising
    {
        recursiveCounter++;

        if (power == 0) return 1;
        if (power == 1) return baseNumber;

        if (power % 2 == 0) return riseToPowerFast(baseNumber * baseNumber, power / 2);
        else return baseNumber * riseToPowerFast(baseNumber * baseNumber, (power - 1) / 2);
    }
}