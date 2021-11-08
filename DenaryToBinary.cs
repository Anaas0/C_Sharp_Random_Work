using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenaryToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int Denary = 0;
            int[] Binary = { 0 }; 
            Console.WriteLine("Enter Number");
            Denary = int.Parse(Console.ReadLine());
            while(Denary != 0)
            {
                Console.WriteLine(Denary % 2);
                Denary = Denary / 2;
            }
            
        }
    }
}
