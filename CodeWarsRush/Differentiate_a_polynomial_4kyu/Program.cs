using System.Numerics;

public class DiffPol
{
    public static HashSet<int> digits = new HashSet<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public class Polynomial
    {
        public long[] polynomial; // "x^22+33x+2" 

        public Polynomial(int power) // base constructor
        {         
            if (power >= 0)
            {
                polynomial = new long[power + 1]; // pol's array initialization
            }
            else
            {
                throw new ArgumentException("The polynomial's power cannot be less than zero");
            }
        }

        public Polynomial(string s) : this(GetMaxPowerFromString(s)) // -5x^2+10x+4678
        {        
            int j = 0; // walking dead index

            while (true) {
              
                bool isNeg = false;
                long num = 0, power = 0;             
                
                if (j < s.Length &&  s[j] == '-') // if we 
                {
                    isNeg = true;
                    j++;
                }

                while (j < s.Length && digits.Contains((int)Char.GetNumericValue(s[j])))
                {
                    num *= 10;
                    num += (int)Char.GetNumericValue(s[j]);
                    j++;
                }

                if (j == s.Length) 
                {
                    this.polynomial[0] = num;
                    break; 
                }

                if (num == 0) num = 1;

                if (isNeg) num *= -1;

                if (s[j] == 'x')
                {
                    j++;

                    if (j < s.Length && s[j] == '^')
                    {
                        j++;

                        while (j < s.Length && digits.Contains((int)Char.GetNumericValue(s[j])))
                        {
                            power *= 10;
                            power += (int)Char.GetNumericValue(s[j++]);
                        }
                    }
                    else
                    {
                        power = 1;
                    }
                }

                this.polynomial[power] = num;

                if (j == s.Length - 1 && digits.Contains((int)Char.GetNumericValue(s[j]))) break;
            
                if (j < s.Length && s[j] == '+') j++;
            }   
        }

        public static int GetMaxPowerFromString(string s) // Levi Jean edition
        {
            int i = 0;

            while (i < s.Length && s[i] != 'x') // "17x^2+1111111x"
            {
                i++;
            } 

            if (i == s.Length) return 0;
            else if (i + 1 == s.Length) return 1;
            else if (s[++i] != '^') return 1;
            else 
            {
                int power = 0;               
                i++;

                while (i < s.Length && digits.Contains((int)Char.GetNumericValue(s[i])))
                {
                    power *= 10;
                    power += (int)Char.GetNumericValue(s[i++]);
                }

                return power;
            }
        }

        public Polynomial DiffPol() 
        {
            // border case of pol.length == 1

            if (GetPower() == 1) return ZeroPolynomial();

            Polynomial newPol = new Polynomial(GetPower() - 1 - 1);

            for (int i = 0; i < GetPower() - 1; i ++) 
            {
                newPol.polynomial[newPol.polynomial.Length - i - 1] = (this.polynomial.Length - i - 1) * this.polynomial[this.polynomial.Length - i - 1];
            }

            return newPol;
        }

        public BigInteger GetValueAtPoint(long x)
        {
            BigInteger value = BigInteger.Zero;

            for (int i = 0; i < this.polynomial.Length; i++) value += this.polynomial[i] * BigInteger.Pow(x, i);

            return value;
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

                copy.polynomial[i] = this.polynomial[i];

            }          

            return copy;
        }

        public static Polynomial ZeroPolynomial()
        { // creates a zero Polynomial
            Polynomial zeroP = new Polynomial(0);
            zeroP.polynomial[0] = 0;

            return zeroP;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Differentiate("12x+2", 3));
        Console.WriteLine(Differentiate("x^2-x", 3));
        Console.WriteLine(Differentiate("-5x^2+10x+4", 3));
        Console.WriteLine(Differentiate("x^2+3x+2", 3));
    }

    public static BigInteger Differentiate(string equation, long x)
    {
        // Your code here!

        Polynomial polynomial = new Polynomial(equation);

        polynomial = polynomial.DiffPol();

        return polynomial.GetValueAtPoint(x);
    }
}