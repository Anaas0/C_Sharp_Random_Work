using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubble_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] UnSortedNumbers = { 7, 5, 11, 2, 3 };
            bool PassAgain;


            BubbleSort(ref UnSortedNumbers);
            Output(UnSortedNumbers);
        }

        public static void Output(int[] Numbers)
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                Console.WriteLine("{0}", Numbers[i]);
            }
        }
        public static void BubbleSort(ref int[] Numbers)
        {
            int temp, Length;
            bool Swap = true;

            Length = Numbers.Length;

            while (Swap == true)
            {
                Swap = false;
                for (int i = 0; i < Length - 1; i++)
                {                    
                    if (Numbers[i] > Numbers[i + 1])
                    {
                        Console.WriteLine("{0} and {1} swapped.", Numbers[i], Numbers[i + 1]);
                        temp = Numbers[i + 1];
                        Numbers[i + 1] = Numbers[i];
                        Numbers[i] = temp;
                        Swap = true;
                    }  
                }
                //decrement length to optimise
            }
            /**/
        }
    }
}
