namespace Serpenskii_Triangle;

public class Serpenskii_Triangle
{

    static void Main(string[] args)
    {
        // choose the method here and uncomment it

        // serpinskiiTriangle(); 

        // serpinskiiSquare();

        // snowFlakeFractal();

        // triangleTrio();

        // rhombFractal();
          
    }

    public static void rhombFractal() {

        Console.Clear(); // we are clearing the console
        Console.WindowWidth = 236; // now the console becomes wider
        int rhombSize = 81;
        int xA = 0, yA = rhombSize;
        int xB = rhombSize, yB = 0;
        int xC = 2 * rhombSize, yC = rhombSize;
        int xD = rhombSize, yD = 2 * rhombSize;

        Console.SetCursorPosition(xA, yA);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB, yB);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC, yC);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD, yD);
        Console.WriteLine("▲");

        // recursive painter call
        recursivePainterRhombFractal(xA, yA, xB, yB, xC, yC, xD, yD);
    }

    public static void recursivePainterRhombFractal(int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD) {

        int xAl = (2 * xA + xB) / 3;
        int yAl = (2 * yA + yB) / 3;

        int xAr = (2 * xA + xD) / 3;
        int yAr = (2 * yA + yD) / 3;

        int xBr = (xA + 2 * xB) / 3;
        int yBr = (yA + 2 * yB) / 3;

        int xBl = (2 * xB + xC) / 3;
        int yBl = (2 * yB + yC) / 3;

        int xCr = (xB + 2 * xC) / 3;
        int yCr = (yB + 2 * yC) / 3;

        int xCl = (2 * xC + xD) / 3;
        int yCl = (2 * yC + yD) / 3;

        int xDr = (xC + 2 * xD) / 3;
        int yDr = (yC + 2 * yD) / 3;

        int xDl = (xA + 2 * xD) / 3;
        int yDl = (yA + 2 * yD) / 3;

        int xAm = xBr;
        int yAm = yA;

        int xBm = xB;
        int yBm = yAl;

        int xCm = xBl;
        int yCm = yC;

        int xDm = xD;
        int yDm = yAr;

        if (xAl == xA || yAl == yB || xBr == xA || yBr == yB || xBl == xB || yBl == yB || xCr == xB || yCr == yB || xCl == xD || yCl == yC || xDr == xD || yDr == yD || 
            xDl == xA || yDl == yA || xAr == xA || yAr == yA) return;
        // stop conditional, when new vertexes cannot be calculated and start repeating

        //here we are painting new vertexes in the console
        Console.SetCursorPosition(xAl, yAl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xBr, yBr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xBl, yBl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xCr, yCr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xCl, yCl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xDr, yDr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xDl, yDl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xAr, yAr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xAm, yAm);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xBm, yBm);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xCm, yCm);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xDm, yDm);
        Console.WriteLine("▲");

        System.Threading.Thread.Sleep(35); // for smoothly painting
        // System.Threading.Thread.Sleep(100); // for smoother painting

        // recursive painter call
        recursivePainterRhombFractal(xBr, yBr, xB, yB, xBl, yBl, xBm, yBm);
        recursivePainterRhombFractal(xA, yA, xAl, yAl, xAm, yAm, xAr, yAr);
        recursivePainterRhombFractal(xAm, yAm, xBm, yBm, xCm, yCm, xDm, yDm);
        recursivePainterRhombFractal(xCm, yCm, xCr, yCr, xC, yC, xCl, yCl);
        recursivePainterRhombFractal(xDl, yDl, xDm, yDm, xDr, yDr, xD, yD);
    }

    public static void triangleTrio() {

        Console.Clear(); // we are clearing the console
        Console.WindowWidth = 236; // now the console becomes wider
        int triangleSize = 234; // 100 is the max default value of console WIDTH
        int xA = triangleSize / 2, yA = 1; // initial values of vertexes coordinates
        int xB = 1, yB = (int)(triangleSize / 2);
        int xC = triangleSize, yC = (int)(triangleSize / 2);

        // initial triangle painting
        Console.SetCursorPosition(xA, yA);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB, yB);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC, yC);
        Console.WriteLine("▲");

        // Console.WriteLine("Max WIDTH: " + Console.LargestWindowWidth);

        // recursive painter call
        recursivePainterTriangleTrio(xA, yA, xB, yB, xC, yC);

    }

    public static void recursivePainterTriangleTrio(int xA, int yA, int xB, int yB, int xC, int yC) {

        int xAr = (2 * xA + xB) / 3;
        int yAr = (2 * yA + yB) / 3;

        int xAl = (2 * xA + xC) / 3;
        int yAl = (2 * yA + yC) / 3;

        int xBl = (xA + 2 * xB) / 3;
        int yBl = (yA + 2 * yB) / 3;

        int xBr = (2 * xB + xC) / 3;
        int yBr = yB;

        int xCr = (xA + 2 * xC) / 3;
        int yCr = (yA + 2 * yC) / 3;

        int xCl = (xB + 2 * xC) / 3;
        int yCl = yC;

        int xO = xA;
        int yO = yBl;

        if (xAr == xB || xBl == xB || yAr == yA || yBl == yA || xAl == xA || xCr == xA || yAl == yA || yCr == yA ||
            xBr == xB || xCl == xB) return;
        // stop conditional, when new vertexes cannot be calculated and start repeating

        //here we are painting new vertexes in the console
        Console.SetCursorPosition(xAr, yAr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xBl, yBl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xAl, yAl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xCr, yCr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xBr, yBr);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xCl, yCl);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xO, yO);
        Console.WriteLine("▲");

        // in the part below we will be doing three recursive calls of this method and so on...

        System.Threading.Thread.Sleep(35); // for smoothly painting
        // System.Threading.Thread.Sleep(100); // for smoother painting

        // here we calls recursivePainter 6 times:

        recursivePainterTriangleTrio(xA, yA, xAr, yAr, xAl, yAl);
        recursivePainterTriangleTrio(xAr, yAr, xBl, yBl, xO, yO);
        recursivePainterTriangleTrio(xBl, yBl, xB, yB, xBr, yBr);
        recursivePainterTriangleTrio(xAl, yAl, xO, yO, xCr, yCr);
        recursivePainterTriangleTrio(xO, yO,xBr, yBr, xCl, yCl);
        recursivePainterTriangleTrio(xCr, yCr, xCl, yCl, xC, yC);
    }

    public static void snowFlakeFractal() {

        Console.Clear(); // we are clearing the console
        Console.WindowWidth = 236; // now the console becomes wider
        int squareSize = 81;
        int xA = 0, yA = 0;
        int xB = 2 * squareSize, yB = 0;
        int xC = 0, yC = squareSize;
        int xD = 2 * squareSize, yD = squareSize;

        // initial square painting
        Console.SetCursorPosition(xA, yA);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB, yB);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC, yC);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD, yD);
        Console.WriteLine("▲");

        recursivePainterSnowFlake(xA, yA, xB, yB, xC, yC, xD, yD);

        for (int i = 0; i < squareSize / 2; i ++) { 

        Console.WriteLine();
        }
    }

    public static void recursivePainterSnowFlake(int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD) {

        // here we are calculating four new vertexes

        int xA1 = (2 * xA + xB) / 3;
        int yA1 = yA;

        int xB1 = (xA + 2 * xB) / 3;
        int yB1 = yB;

        int xA2 = xA;
        int yA2 = (2 * yA + yC) / 3;

        int xB2 = xB;
        int yB2 = (2 * yB + yD) / 3;

        int xC2 = xC;
        int yC2 = (yA + 2 * yC) / 3;

        int xD2 = xD;
        int yD2 = (yB + 2 * yD) / 3;

        int xC1 = (2 * xC + xD) / 3;
        int yC1 = yC;

        int xD1 = (xC + 2 * xD) / 3;
        int yD1 = yD;

        int xA3 = (2 * xA + xB) / 3;
        int yA3 = (2 * yA + yC) / 3;

        int xB3 = (xA + 2 * xB) / 3;
        int yB3 = (2 * yB + yD) / 3;

        int xC3 = (2 * xC + xD) / 3;
        int yC3 = (yA + 2 * yC) / 3;

        int xD3 = (xC + 2 * xD) / 3;
        int yD3 = (yB + 2 * yD) / 3;

        if (xA1 == xA || xB1 == xA || xC1 == xC || xD1 == xC || yA2 == yA || yC2 == yA || yB2 == yB || yD2 == yB ||
            xA3 == xA || yA3 == yA || xB3 == xA || yB3 == yB || xC3 == xC || yC3 == yA || xD3 == xB || yD3 == yB) return;

        Console.SetCursorPosition(xA1, yA1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xA2, yA2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xA3, yA3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB1, yB1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB2, yB2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB3, yB3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC1, yC1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC2, yC2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC3, yC3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD1, yD1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD2, yD2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD3, yD3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xA, yA);
        Console.WriteLine(" ");

        Console.SetCursorPosition(xB, yB);
        Console.WriteLine(" ");

        Console.SetCursorPosition(xC, yC);
        Console.WriteLine(" ");

        Console.SetCursorPosition(xD, yD);
        Console.WriteLine(" ");

        System.Threading.Thread.Sleep(35); // for smoothly painting
        // System.Threading.Thread.Sleep(100); // for smoother painting

        // recursivePainterSnowFlake(xA, yA, xA1, yA1, xA2, yA2, xA3, yA3);
        recursivePainterSnowFlake(xA1, yA1, xB1, yB1, xA3, yA3, xB3, yB3);
        // recursivePainterSnowFlake(xB1, yB1, xB, yB, xB3, yB3, xB2, yB2);
        recursivePainterSnowFlake(xA2, yA2, xA3, yA3, xC2, yC2, xC3, yC3);
        recursivePainterSnowFlake(xB3, yB3, xB2, yB2, xD3, yD3, xD2, yD2);
        // recursivePainterSnowFlake(xC2, yC2, xC3, yC3, xC, yC, xC1, yC1);
        recursivePainterSnowFlake(xC3, yC3, xD3, yD3, xC1, yC1, xD1, yD1);
        // recursivePainterSnowFlake(xD3, yD3, xD2, yD2, xD1, yD1, xD, yD);

        recursivePainterSnowFlake(xA3, yA3, xB3, yB3, xC3, yC3, xD3, yD3); // -> central square
    }

    public static void serpinskiiSquare() {

        Console.Clear(); // we are clearing the console
        Console.WindowWidth = 236; // now the console becomes wider
        int squareSize = 81;
        int xA = 0, yA = 0;
        int xB = 2 * squareSize, yB = 0;
        int xC = 0, yC = squareSize;
        int xD = 2 * squareSize, yD = squareSize;

        // initial square painting
        Console.SetCursorPosition(xA, yA);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB, yB);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC, yC);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD, yD);
        Console.WriteLine("▲");

        recursivePainterSquare(xA, yA, xB, yB, xC, yC, xD, yD);
    }

    public static void recursivePainterSquare(int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD) {

        // here we are calculating four new vertexes

        int xA1 = (2 * xA + xB) / 3;
        int yA1 = yA;

        int xB1 = (xA + 2 * xB) / 3;
        int yB1 = yB;

        int xA2 = xA;
        int yA2 = (2 * yA + yC) / 3;

        int xB2 = xB;
        int yB2 = (2 * yB + yD) / 3;

        int xC2 = xC;
        int yC2 = (yA + 2 * yC) / 3;

        int xD2 = xD;
        int yD2 = (yB + 2 * yD) / 3;

        int xC1 = (2 * xC + xD) / 3;
        int yC1 = yC;

        int xD1 = (xC + 2 * xD) / 3;
        int yD1 = yD;

        int xA3 = (2 * xA + xB) / 3;
        int yA3 = (2 * yA + yC) / 3;

        int xB3 = (xA + 2 * xB) / 3;
        int yB3 = (2 * yB + yD) / 3;

        int xC3 = (2 * xC + xD) / 3;
        int yC3 = (yA + 2 * yC) / 3;

        int xD3 = (xC + 2 * xD) / 3;
        int yD3 = (yB + 2 * yD) / 3;

        if (xA1 == xA || xB1 == xA || xC1 == xC || xD1 == xC || yA2 == yA || yC2 == yA || yB2 == yB || yD2 == yB || 
            xA3 == xA || yA3 == yA || xB3 == xA || yB3 == yB || xC3 == xC || yC3 == yA || xD3 == xB || yD3 == yB) return;

        Console.SetCursorPosition(xA1, yA1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xA2, yA2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xA3, yA3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB1, yB1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB2, yB2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB3, yB3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC1, yC1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC2, yC2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC3, yC3);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD1, yD1);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD2, yD2);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xD3, yD3);
        Console.WriteLine("▲");

        System.Threading.Thread.Sleep(35); // for smoothly painting
        // System.Threading.Thread.Sleep(100); // for smoother painting

        recursivePainterSquare(xA, yA, xA1, yA1, xA2, yA2, xA3, yA3);
        recursivePainterSquare(xA1, yA1, xB1, yB1, xA3, yA3, xB3, yB3);
        recursivePainterSquare(xB1, yB1, xB, yB, xB3, yB3, xB2, yB2);
        recursivePainterSquare(xA2, yA2, xA3, yA3, xC2, yC2, xC3, yC3);
        recursivePainterSquare(xB3, yB3, xB2, yB2, xD3, yD3, xD2, yD2);
        recursivePainterSquare(xC2, yC2, xC3, yC3, xC, yC, xC1, yC1);
        recursivePainterSquare(xC3, yC3, xD3, yD3, xC1, yC1, xD1, yD1);
        recursivePainterSquare(xD3, yD3, xD2, yD2, xD1, yD1, xD, yD);
        //recursivePainterSnowFlake(xA3, yA3, xB3, yB3, xC3, yC3, xD3, yD3); // -> we does not use central square here
    }
    public static void serpinskiiTriangle() {

        Console.Clear(); // we are clearing the console
        Console.WindowWidth = 236; // now the console becomes wider
        int triangleSize = 128; // 100 is the max value of console WIDTH
        int xA = triangleSize / 2, yA = 1; // initial values of vertexes coordinates
        int xB = 1, yB = (int)(triangleSize / 2);
        int xC = triangleSize, yC = (int)(triangleSize / 2);

        // initial triangle painting
        Console.SetCursorPosition(xA, yA);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xB, yB);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xC, yC);
        Console.WriteLine("▲");

        // Console.WriteLine("Max WIDTH: " + Console.LargestWindowWidth);

        // recursive painter call
        recursivePainterTriangle(xA, yA, xB, yB, xC, yC);

        Console.WriteLine(); // prociding to the next line for convenience
        string s = "                              Sergey Kamyanetskii grustit ne po-detski!!!                                               HAHAHA!";

        for (int i = 0; i < s.Length; i++)
        {
            Console.Write(s[i]);
            System.Threading.Thread.Sleep(35);
        }

        Console.WriteLine();
    }

    public static void recursivePainterTriangle(int xA, int yA, int xB, int yB, int xC, int yC)
    {
        // here we are calculating three new vertexes
        int xAmirrored = xA; // a particular case (isosceles triangle), in general: xAmirrored = (xB + xC) / 2
        int yAmirrored = yB; // a paticular case (isosceles triangle), in general: yAmirrored = (yB + yC) / 2

        int xCmirrored = (xA + xB) / 2;
        int yCmirrored = (yA + yB) / 2;

        int xBmirrored = (xA + xC) / 2;
        int yBmirrored = (yA + yC) / 2;

        if (xCmirrored == xA || xBmirrored == xA || yCmirrored == yA || yBmirrored == yA) return;
        // stop conditional, when new vertexes cannot be calculated and start repeating

        //here we are painting new vertexes in the console
        Console.SetCursorPosition(xAmirrored, yAmirrored);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xBmirrored, yBmirrored);
        Console.WriteLine("▲");

        Console.SetCursorPosition(xCmirrored, yCmirrored);
        Console.WriteLine("▲");

        // in the part below we will be doing three recursive calls of this method and so on...

        System.Threading.Thread.Sleep(35); // for smoothly painting
        // System.Threading.Thread.Sleep(100); // for smoother painting

        // recursivePainter(xAmirrored, yAmirrored, xBmirrored, yBmirrored, xCmirrored, yCmirrored); -> inner triabgle must not be fullfilled
        recursivePainterTriangle(xCmirrored, yCmirrored, xB, yB, xAmirrored, yAmirrored); // Bvertex-triangle
        recursivePainterTriangle(xA, yA, xCmirrored, yCmirrored, xBmirrored, yBmirrored); // Avertex-triangle
        recursivePainterTriangle(xBmirrored, yBmirrored, xAmirrored, yAmirrored, xC, yC); // Cvertex-triangle
    }
}