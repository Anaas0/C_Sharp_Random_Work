using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> test = new BinaryTree<string>();

            test.Add("Rod");
            test.Add("Jane");
            test.Add("Freddie");
            test.Add("Bungle");
            test.Add("Zippy");
            test.InOrderTraverse();
        }
    }
    class BinaryTree<T>
    {
        private Node _Root;

        public BinaryTree()
        {
            _Root = null;
        }

        public class Node
        {
            public string _Data;
            public Node _Left;
            public Node _Right;

            public Node(string inData)
            {
                _Data = inData;
            }
            public Node(string inData, Node inLeft, Node inRight)
            {
                _Data = inData;
                _Left = null;
                _Right = null;
            }
        }
        
        public void Add(string inData)
        {
                Add(ref _Root, inData);           
        }
        private void Add(ref Node inPosition, string inData)
        {
            if (inPosition == null)
            {
                inPosition = new Node(inData);//base case                
            }
            else
            {
                if (string.Compare(inPosition._Data, inData) == 1)//Root is less than Data
                {
                    Add(ref inPosition._Left, inData);
                }
                else //if (string.Compare(_Root._Data, inData) == -1)//Root is greater than data
                {
                    Add(ref inPosition._Right, inData);
                }
            }                
        }

        public void InOrderTraverse()
        {
            InOrderTraverse(_Root);
        }
        private void InOrderTraverse(Node inPosition)
        {
        //output when passing to left (pre-order)
            if(inPosition._Left != null)
            {
                InOrderTraverse(inPosition._Left);
            }

            Console.WriteLine(inPosition._Data);//Base Case - not a recursive call. output when passing underneath (in order)

            if (inPosition._Right != null)
            {
                InOrderTraverse(inPosition._Right);
            }  
            //output when passing to right (Post-order)
        }

        public void PreOrder()
        {

        }
        private void PreOrder(Node inPosition)
        {
            Console.WriteLine();
        }
    }
}
