public class MaxSubSquare // Представьте, что существует квадратная матрица, каждый пиксель которой может быть черным или белым.
                          // Разработайте алгоритм поиска максимального субквадрата, у которого все стороны черные
{
    public static int[,,] prefixOnesQuantities;

    static void Main(string[] args)
    {               
        int[,] matrix = new int[,] { // test case
            { 0, 1, 0, 1, 0, 1, 1 }, 
            { 0, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 1, 0, 0, 1, 1 }, 
            { 1, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 0, 1, 0 } 
        };              

        Console.WriteLine($"\nMax sub square area: " + FindMaxSquareArea(matrix)); // method call
    }

    public static int FindMaxSquareArea(int[,] matrix) // a method body, O(jMax * iMax * min(jMax, iMax)) runtime and
                                                       // O(jMax * iMax) additional memory
    { 
        PreCalc(matrix); // here the pre-calculations start

        int maxSquareSize = 0; // the car for the current max square size

        int jMax = 0, iMax = 0; // the coords of the top left corner of the max (in terms of size) square

        for (int j = 0; j < matrix.GetLength(0) && matrix.GetLength(0) - j > maxSquareSize; j++) // outer coords cycle -> rows, there is
                                                                                                 // an important stop condition. If we got
                                                                                                 // some square with a size that is bigger
                                                                                                 // than the rows remained we can break the cycle
        {
            for (int i = 0; i < matrix.GetLength(1); i++) // inner coords cycle -> columns
            {
                for (int squareSize = 1; squareSize <= Math.Min(matrix.GetLength(0) -
                    j, matrix.GetLength(1) - i); squareSize++) // cycling all over the possible square sizes in the current point:
                                                               // coordinates (j, i)
                {
                    if (DoesSquarePerimeterConsistOfOnes(j, i, squareSize, matrix)) // here we call the method which checks if the square
                                                                                    // filled with the only 1s
                    {
                        if (squareSize > maxSquareSize) // now if the current square size is bigger than the current max square size
                                                        // we write the new square size value in the max square size variable
                        { 
                            maxSquareSize = squareSize; // renew the max square size var's value

                            jMax = j; // renew the max square's coords
                            iMax = i;
                        }
                    }
                }
            }
        }

        Console.WriteLine($"\njMax, iMax: ({jMax},{iMax})"); // printing the position of the top left corner of the max aquare

        return maxSquareSize; // return the max aquare size
    }

    public static bool DoesSquarePerimeterConsistOfOnes(int j, int i, int squareSize, int[,] matrix) // here we use the results
                                                                                                     // of the PreCalc method
    {       
        if (prefixOnesQuantities[j, i + squareSize - 1, 0] - prefixOnesQuantities[j, i, 0] + 1 != squareSize) // top horizontal
        { 
            return false; // returns false if at least one condition breaks
        }

        if (prefixOnesQuantities[j + squareSize - 1, i + squareSize - 1, 0] - 
            prefixOnesQuantities[j + squareSize - 1, i, 0] + 1 != squareSize) // down horizontal
        {
            return false;
        }

        if (prefixOnesQuantities[j + squareSize - 1, i, 1] - prefixOnesQuantities[j, i, 1] + 1 != squareSize) // left vertical
        {
            return false;
        }

        if (prefixOnesQuantities[j + squareSize - 1, i + squareSize - 1, 1] - 
            prefixOnesQuantities[j, i + squareSize - 1, 1] + 1 != squareSize) // right vertical
        {
            return false;
        }

        return true; // return true if and only if all the conditions met
    }

    public static void PreCalc(int[,] matrix) // here we fill prefixOnesQuantities "prefix" array -> we accelerate the method
                                              // that checks if the square is 1s filled or not from O(max(jMax, iMax)) to O(1)
    {
        prefixOnesQuantities = new int[matrix.GetLength(0), matrix.GetLength(1), 2];

        int onesQuantity;

        for (int j = 0; j < matrix.GetLength(0); j++) // here we fills the rows prefix array (0-indexed in our 3D array)
        {
            onesQuantity = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                 onesQuantity += matrix[j, i] == 1 ? 1 : 0; 
                
                 prefixOnesQuantities[j, i, 0] = onesQuantity;
            }
        }

        for (int i = 0; i < matrix.GetLength(1); i++) // here we fills the columns prefix array (1-indexed in our 3D array)
        {
            onesQuantity = 0;

            for (int j = 0; j < matrix.GetLength(0); j++) 
            {
                onesQuantity += matrix[j, i] == 1 ? 1 : 0;

                prefixOnesQuantities[j, i, 1] = onesQuantity;
            }
        }
    }
}