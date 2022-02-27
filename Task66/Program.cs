public class Task66 {

    public static void Main(String[] args)
    {

        recursiveSeeker(100);

        backRecursiveSeeker(1, 100);

        // rec1();
        // rec2();

    }

    public static void recursiveSeeker(int n)
    {

        if (n == 1)
        { 
            Console.WriteLine(1);
            return;
        }

        Console.Write(n + " ");

        recursiveSeeker(n - 1);
    }

    public static void backRecursiveSeeker(int n, int N) { 

        if (n == N)
        {
            Console.WriteLine(n);
            return;
        }

        Console.Write(n + " ");

        backRecursiveSeeker(n + 1, N);
    }

    public static int rec1() { // to show that bad recursion leads us to a CATASTROFIC consequinces
        return rec2();
    }

    public static int rec2() { // to show that bad recursion leads us to a CATASTROFIC consequinces
        return rec1();
    }


    

}
