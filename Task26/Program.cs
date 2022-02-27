public class Task26 {



    static void Main(string[] args)
    {
        double A = 5.34;
        int B = 10;

        Console.WriteLine("Result = " + pow(A, B));      
            
    }

    public static double pow(double number, int power) {

        double result = 1;

        for (int i = 0; i < power; i++) 
        {         
            result *= number;
        }

        return result;

    }


}