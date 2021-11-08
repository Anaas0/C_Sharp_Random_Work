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
            int[] List = { 3, 6, 7, 11, 15, 16, 21, 100 };
            int WantedNo = 100;

            Console.WriteLine("Index Number: {0}",BinarySearch(List, 0, List.Length - 1, WantedNo));
        }

        static int BinarySearch(int[] inList, int inFront, int inLast, int inWantedNo)
        {
            int MidPoint;
            MidPoint = (inFront + inLast) / 2;

            if (inWantedNo == inList[MidPoint]) return MidPoint;
            else if (inFront >= inLast) return -1;
            else
            {
                if (inList[MidPoint] > inWantedNo) return BinarySearch(inList, 0, MidPoint - 1, inWantedNo);
                else return BinarySearch(inList, MidPoint + 1, inLast, inWantedNo);
            }           
        }
    }
}