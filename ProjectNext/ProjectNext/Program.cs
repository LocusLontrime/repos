using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNext
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ulong number = ulong.MaxValue;
            Console.WriteLine(number);

            decimal number2 = 1000; 
            Console.WriteLine(number2 / 99 + " " + 366);

            Console.WriteLine(new Random().Next(1,100));

        }
    }
}
