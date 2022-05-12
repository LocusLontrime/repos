public class KaprekarsConstant // Пусть функция KaprekarsConstant(num) получает для передачи параметр num — четырехзначное число
                               // с как минимум двумя различными цифрами. Программа должна производить с этим числом следующие действия:
                               // упорядочивать его цифры по возрастанию и убыванию (добавляя нули для получения четырехзначного числа),
                               // а затем вычитать меньшее число из большего. Далее она должна повторять предыдущий шаг.
                               // Выполнение этого процесса всегда в итоге будет приводить вас к результату 6174 (7641–1467=6174).
                               // Программа также должна возвращать количество повторов, потребовавшихся для достижения этого значения.
                               // Например, если num равен 3524, программа должна вернуть 3, вот её три шага: 

// (1) 5432–2345 = 3087
// (2) 8730–0387 = 8352
// (3) 8532–2358 = 6174

{
    public static List<int> kaprekars = new List<int>();

    static void Main(string[] args)
    {
        for (int i = 1; i <= 9; i++) kaprekars.Add(1000 * i + 100 * i + 10 * i + i);

        Console.WriteLine(KaprekarsConstantRecursive(9745));

        int maxSteps = 0;
        int maxStepsNumber = 0;

        for (int i = 1000; i <= 9999; i++) // checks all the numbers
        {
            if (!kaprekars.Contains(i))
            {

                int currentSteps = KaprekarsConstantRecursive(i);

                if (maxSteps < currentSteps)
                {
                    maxSteps = currentSteps;
                    maxStepsNumber = i;
                }
            }
        }

        Console.WriteLine(maxStepsNumber + " has been made with " + maxSteps);
    }

    public static int KaprekarsConstantRecursive(int number)
    {
        // base cases:
        if (number == 6174) return 0;

        // recursive body

        List<int> digits = GetDigitsRec(number, new List<int>());

        digits.Sort(); // sorting 

        int newNumber = GetNumberFromDecreasingDigits(digits) - GetNumberFromIncreasingDigits(digits); // building new number

        while (newNumber < 1000) newNumber *= 10; // tranforming the number to 4-digits form         

        // reccurent relation
        return KaprekarsConstantRecursive(newNumber) + 1;
    }

    public static List<int> GetDigitsRec(int number, List<int> listOfDigits) // get all numbers
    {
        if (number == 0) return listOfDigits;

        listOfDigits.Add(number % 10);

        return GetDigitsRec(number / 10, listOfDigits);
    }

    public static int GetNumberFromIncreasingDigits(List<int> listOfDigits)
    {
        int resultNumber = 0; // Nimbus 2000

        for (int i = 0; i < listOfDigits.Count; i++)
        {
            resultNumber *= 10;
            resultNumber += listOfDigits[i];
        }

        return resultNumber;
    }

    public static int GetNumberFromDecreasingDigits(List<int> listOfDigits)
    {
        int resultNumber = 0; // Nimbus 2000

        for (int i = listOfDigits.Count - 1; i >= 0; i--)
        {
            resultNumber *= 10;
            resultNumber += listOfDigits[i];
        }

        return resultNumber;
    }
}