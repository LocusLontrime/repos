public class MaxProduct // Дан массив с целыми числами, в том числе и отрицательными,
                        // вам нужно найти самое большое произведение 3 чисел из этого массива
{
    static void Main(string[] args)
    {
        int[] array = new int[] { 1, 0, -55, 6, 7, 78, -1, -1, -98, -77, 0, -1, 4, 44, -9, -98, -1, -1, 77, 99, -99};

        Console.WriteLine(MaxProductOf2(array) + " " + 99 * 98);

        Console.WriteLine("\n" + MaxProductOf3(array) + " " + 99 * 99 * 98);

        Console.WriteLine("\n" + MaxProductOfN(array, 1) + " " + MaxProductOfN(array, 2) + " " + MaxProductOfN(array, 3));
    }

    public static int MaxProductOf2(int[] array) // for the better understanding of what is happening
    {
        int maxNum = array[0], minNum = array[0];
        int maxCurrProd = array[0] * array[1];

        for (int i = 1; i < array.Length; i++)
        {          
            maxCurrProd = Math.Max(maxCurrProd, Math.Max(array[i] * maxNum, array[i] * minNum));

            maxNum = Math.Max(maxNum, array[i]);
            minNum = Math.Min(minNum, array[i]);
        }

        return maxCurrProd;
    }

    public static int MaxProductOf3(int[] array) // the original task itself
    {
        int maxNum = array[0], minNum = array[0];
        int maxProdOf2 = array[0] * array[1], minProdOf2 = array[0] * array[1];
        int maxCurrProd = array[0] * array[1] * array[3];

        for (int i = 2; i < array.Length; i++)
        {
            maxCurrProd = Math.Max(maxCurrProd, Math.Max(array[i] * maxProdOf2, array[i] * minProdOf2));

            maxProdOf2 = Math.Max(maxProdOf2, Math.Max(array[i] * maxNum, array[i] * minNum));
            minProdOf2 = Math.Min(minProdOf2, Math.Min(array[i] * maxNum, array[i] * minNum));

            maxNum = Math.Max(maxNum, array[i]);
            minNum = Math.Min(minNum, array[i]);
        }

        return maxCurrProd;
    }

    public static int MaxProductOfN(int[] array, int N) // a general version, O(array.Length * N) runtime, O(N) additional memory
    {
        int[,] products = new int[N, 2]; // here we keep the min and max products (from 1 element to N)

        // initial values initialization, no matter what is located in product[N - 1, 1] -> we do not use this value
        for (int j = 0; j < N; j++)           
        {
            products[j, 0] = 1;
            products[j, 1] = 1;

            for (int i = 0; i <= j; i++)
            { 
                products[j, 0] *= array[i];
                products[j, 1] *= array[i];
            }
        }

        // the algo itself
        for (int j = N - 1; j < array.Length; j++)
        {
            for (int i = N - 1; i >= 0; i--)
            {
                // the first conditioin "if" is for the case of finding the max element in the array, second -> we calculate the max product of N
                if (N != 1 && i == N - 1) products[i, 0] = Math.Max(products[i, 0], Math.Max(array[j] * products[i - 1, 0], array[j] * products[i - 1, 1]));
                else if (i == 0) // auxiliary products computing 
                {
                    products[i, 0] = Math.Max(products[i, 0], array[j]);
                    products[i, 1] = Math.Min(products[i, 1], array[j]);
                }
                else // redefining thr max and min current values at the every step of the j-for cycle
                {
                    products[i, 0] = Math.Max(products[i, 0], Math.Max(array[j] * products[i - 1, 0], array[j] * products[i - 1, 1]));
                    products[i, 1] = Math.Min(products[i, 1], Math.Min(array[j] * products[i - 1, 0], array[j] * products[i - 1, 1]));
                }
            }      
        }

        return products[N - 1, 0]; // returning the result
    }
}