public class GeniousLena // Показать все числа от M до N, которые делятся или на 3, или на 5 (или на 3 и 5 сразу)
{

    static void Main(string[] args)
    {
        PrintRec(1, 900);
    }

    public static void PrintRec(int M, int N) 
    {
        // border case
        if (M == N + 1) return;

        // do phase
        if (M % 3 == 0 || M % 5 == 0) Console.Write(M + " ");       

        // recursive call
        PrintRec(M + 1, N);
    }
}