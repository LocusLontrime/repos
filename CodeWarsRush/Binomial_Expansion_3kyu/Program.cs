using System.Text;

public class BinomialExpansion // accepted on codewars
{
    public static HashSet<int> digits = new HashSet<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

    public class Polynomial
    {
        public long[] polynomial; // the polynomial itself in array representation
        public char variable;

        public Polynomial(int power) // base constructor
        {
            variable = 'x'; // default value of a variable

            if (power >= 0)
            {
                polynomial = new long[power + 1]; // pol's array initialization
            }
            else
            {
                throw new ArgumentException("The polynomial's power cannot be less than zero");
            }
        }

        public static Polynomial GetLinearPolynomial(string s) 
        {
            Polynomial linearPol = new Polynomial(1);

            int j = 0;
            bool isLeftNeg = false, isRightNeg = false;
            long leftNum = 0, rightNum = 0;

            if (s[j] == '-') 
            { 
                isLeftNeg = true;
                j++;
            }

            while (digits.Contains((int)Char.GetNumericValue(s[j]))) 
            {
                leftNum *= 10;
                leftNum += (int) Char.GetNumericValue(s[j++]);
            }

            if (leftNum == 0) leftNum = 1;

            if (isLeftNeg) leftNum *= -1;

            linearPol.variable = s[j++];

            if (s[j] == '-')
            {
                isRightNeg = true;
                j++;
            }
            else j++;         

            while (j < s.Length && digits.Contains((int)Char.GetNumericValue(s[j])))
            {
                rightNum *= 10;
                rightNum += (int)Char.GetNumericValue(s[j++]);
            }

            if (isRightNeg) rightNum *= -1;

            linearPol.polynomial[0] = rightNum;
            linearPol.polynomial[1] = leftNum;

            return linearPol;
        }

        public void Simplify()
        { // simplifies the polynomial by erasing fields with zero coefficients
            int powerCounter = GetPower();

            for (int i = GetPower() - 1; i >= 0; i--)
            {
                if (this.polynomial[i] == 0) powerCounter--;
                else break;
            }

            long[] simplifiedP = new long[powerCounter];

            for (int i = 0; i < powerCounter; i++)
            {
                simplifiedP[i] = this.polynomial[i];
            }

            if (simplifiedP.Length == 0)
            {
                simplifiedP = new long[1];
                simplifiedP[0] = 0;
            }

            this.polynomial = simplifiedP;
        }

        public Polynomial Add(Polynomial polynomial)
        { // calculates the sum of two polynomials
            Polynomial M = new Polynomial(Math.Max(this.GetPower(), polynomial.GetPower()) - 1);
            Polynomial maxP;

            if (this.GetPower() == M.GetPower()) maxP = this.Copy();
            else maxP = polynomial.Copy();

            int minPower = Math.Min(this.GetPower(), polynomial.GetPower());

            for (int i = 0; i < minPower; i++)
            {
                M.polynomial[i] = this.polynomial[i] + polynomial.polynomial[i];
            }

            for (int i = minPower; i < M.GetPower(); i++)
            {
                M.polynomial[i] = maxP.polynomial[i];
            }

            return M;
        }

        public Polynomial MultiplyByNumber(long number)
        { // multiplies the polynomial by fraction
            if (number == 0)
            {
                return Polynomial.ZeroPolynomial();
            }

            Polynomial M = new Polynomial(this.GetPower() - 1);

            for (int i = 0; i < M.GetPower(); i++)
            {
                M.polynomial[i] = this.polynomial[i] * number;
            }

            return M;
        }

        public Polynomial Multiply(Polynomial polynomial)
        { // multiplies polynomial by another one
            Polynomial M = new Polynomial(this.GetPower() + polynomial.GetPower() - 2); // a power of a new one
            M.variable = this.variable;
            M.ZeroFulfilling();

            for (int i = 0; i < this.GetPower(); i++)
            {
                for (int j = 0; j < polynomial.GetPower(); j++)
                {
                    M.polynomial[i + j] += this.polynomial[i] * polynomial.polynomial[j];
                }
            }

            return M;
        }

        public Polynomial RaiseToPowerFastRec(int power) // ??? really fast or not ???
        { // rises the polynomial to the power of

            if (power < 0)
            {
                throw new ArgumentException("The power of polynomial cannot be less than zero!");
            }
            else if (power == 0)
            {
                return OnePolynomial();
            }

            return MatrixPowRecursive(this.Copy(), power);
        }

        public static Polynomial MatrixPowRecursive(Polynomial polynomial, int power)
        {
            if (power == 0) return OnePolynomial();
            if (power == 1) return polynomial;

            if (power % 2 == 0) return MatrixPowRecursive(polynomial.Multiply(polynomial), power / 2);
            else return polynomial.Multiply(MatrixPowRecursive(polynomial.Multiply(polynomial), (power - 1) / 2));
        }

        private void ZeroFulfilling()
        { // fulfill the polynomial by zero values of fractions
            for (int i = 0; i < this.GetPower(); i++)
            {
                polynomial[i] = 0;
            }
        }

        public int GetPower()
        { // returns length of polynomial (power + 1)
            return polynomial.Length;
        }

        public Polynomial Copy()
        { // makes the copy of base polynomial to prevent the changes in the base polynomial when the copy is being operated
            Polynomial copy = new Polynomial(GetPower() - 1);

            for (int i = 0; i < GetPower(); i++) 
            { 

                copy.polynomial[i] = this.polynomial[i]; ;

            }

            copy.variable = this.variable;

            return copy;
        }

        public bool Equals(Polynomial polynomial)
        { // equalling of two polynomials

            if (GetPower() != polynomial.GetPower()) return false;

            bool isEqual = true;

            for (int i = 0; i < GetPower(); i++)
            {
                if (this.polynomial[i] != polynomial.polynomial[i])
                {
                    isEqual = false;
                    break;
                }

            }

            return isEqual;
        }

        public static Polynomial ZeroPolynomial()
        { // creates a zero Polynomial
            Polynomial zeroP = new Polynomial(0);
            zeroP.polynomial[0] = 0;

            return zeroP;
        }

        public static Polynomial OnePolynomial()
        { // creates 1-polynomial
            Polynomial oneP = new Polynomial(0);
            oneP.polynomial[0] = 1;

            return oneP;
        }

        public string PolToString() 
        {
            StringBuilder str = new StringBuilder("");

            if (this.Equals(ZeroPolynomial()))
            {
                return "0";
            }

            char sym = this.variable;

            if (this.polynomial[polynomial.Length - 1] < 0) str.Append("-"); // the sign of a0 monomial

            for (int i = GetPower() - 1; i >= 0; i--)
            { // polynomial printing after defining of the first sigh
                if (i > 1)
                {
                    string s;

                    if (polynomial[i - 1] < 0)
                    {
                        s = "-";
                    }
                    else if (polynomial[i - 1] > 0) s = "+";
                    else s = "";

                    if (polynomial[i] == 0)
                    {
                        str.Append(s);
                    }
                    else if (polynomial[i] == 1)
                    {
                        str.Append(sym).Append("^").Append(i).Append(s);
                    }
                    else if (polynomial[i] == -1)
                    {
                        str.Append(sym).Append("^").Append(i).Append(s);
                    }
                    else
                    {
                        str.Append(Math.Abs(polynomial[i]));
                        str.Append(sym).Append("^").Append(i).Append(s);
                    }
                }
                else if (i == 1)
                {
                    if (polynomial[1] == 0)
                    {
                        if (polynomial[0] > 0)
                        {
                            str.Append("+");
                        }
                        else if (polynomial[0] < 0)
                        {
                            str.Append("-");
                        }                       
                    }
                    else
                    {
                        if (polynomial[i] != 1 && polynomial[i] != -1)
                        {
                            str.Append(Math.Abs(polynomial[i]));
                        }                       

                        if (polynomial[0] > 0)
                        {
                            str.Append(sym).Append("+");
                        }
                        else if (polynomial[0] < 0)
                        {
                            str.Append(sym).Append("-");
                        }
                        else
                        {
                            str.Append(sym);
                        }
                    }
                }
                else
                {
                    if (polynomial[0] != 0) str.Append(Math.Abs(polynomial[i]));
                }
            }

            return str.ToString();
        }
    }

    static void Main(string[] args)
    {
        //Polynomial polynomial = Polynomial.GetLinearPolynomial("-12t+43");
        Console.WriteLine(Expand("(-12t+43)^2"));
        Console.WriteLine(Expand("(5m+3)^4"));
        Console.WriteLine(Expand("(2x-3)^3"));                  
        Console.WriteLine(Expand("(x-1)^1"));
        Console.WriteLine(Expand("(-2k-3)^3"));
        Console.WriteLine(Expand("(r+0)^203"));
    }

    public static string Expand(string expr)
    {
        string[] parts = expr.Split('^');
        int power = int.Parse(parts[1]);

        parts[0] = parts[0].Replace("(", "");
        parts[0] = parts[0].Replace(")", "");       
        Polynomial pol = Polynomial.GetLinearPolynomial(parts[0]);

        if (power == 0) return "1";
        else if (power == 1) return pol.PolToString();

        if (pol.polynomial[0] == 0) return (pol.polynomial[1] != 1 ? Math.Pow(pol.polynomial[1], power).ToString() : "") + pol.variable.ToString() + "^" + power;

        return pol.RaiseToPowerFastRec(power).PolToString();
    }
}