using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryChop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(4));
        }
        static int Factorial(int n)
        {
            int Fact;

            if (n == 1)
                return 1;
            else
            {
                Fact = n * Factorial(n - 1);
                return Fact;
            }

        }
    }
}
