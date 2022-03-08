public class AddTask10 //Дана игра со следующими правилами. Первый игрок называет любое натуральное число от 2 до 9,
                       //второй умножает его на любое натуральное число от 2 до 9, первый умножает результат
                       //на любое натуральное число от 2 до 9 и т. д. Выигрывает тот, у кого впервые получится число больше 1000.
                       //Запрограммировать консольный вариант игры
{
    public static void Main(string[] args)
    {
        Game(); // method call
    }

    public static void Game() // main method
    {
        bool theGameIsOn = true;

        int result = 0;
        int counter = 1; // First player begins the game

        int number = 0;

        Console.WriteLine("THE GAME BEGINS... \n");

        while (true) // the main cycle
        {
            string player = counter++ % 2 == 0 ? "Second " : "First ";
            Console.WriteLine(player + " player's turn, enter a number:");

            while (true) // cycle of number choosing
            {
                string str = Console.ReadLine();

                if (str.Equals("Exit")) // if we can stop the game
                { 
                    theGameIsOn = false;
                    Console.WriteLine("\nThanks for playing!");
                    break;
                }                   

                if (int.TryParse(str, out number) && number >= 2 && number <= 9)
                {
                    Console.WriteLine(player + " player chooses " + number + " number! \n");
                    break;
                }
                else 
                {
                    Console.WriteLine("The number is out of range you should enter a number that is larger than 1 and less than 10");
                }
            }

            if (!theGameIsOn) break;

            result = result == 0 ? number : result * number;

            if (result > 1000) 
            {
                Console.WriteLine("The " + player + "player wins, having scored " + result + " points");
                break;
            }
        }   
    }
}