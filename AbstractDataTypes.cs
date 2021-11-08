using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDataType
{
    class Program
    {
        class LQueue<T>
        {
            public const int _MAX = 5;
            public int _FrontPointer;
            public int _RearPointer;
            public int _QueueSize;
            public T[] _Queue = new T[_MAX];

            public LQueue()
            {
                _RearPointer = -1;
                _FrontPointer = 0;
            }

            public virtual bool IsEmpty
            {
                get
                {
                    if (_RearPointer == -1)
                        return true;
                    else
                        return false;
                }
            }

            public virtual bool IsFull
            {
                get
                {
                    if (_RearPointer == _MAX - 1)
                        return true;
                    else return false;
                }
            }

            public void AddItem(T inItem)
            {
                if (IsFull == true)
                    Console.WriteLine("Queue Full");
                else
                    _Queue[++_RearPointer] = inItem;
                Console.WriteLine("Front:{0}", _FrontPointer);
                Console.WriteLine("Rear:{0}", _RearPointer);
            }

            public virtual T RemoveItem()
            {
                if (IsEmpty == true)
                {
                    Console.WriteLine("Queue is empty");
                    throw new Exception("REMOVE ITEM FUNCTION");
                }
                else
                {
                    Console.WriteLine("Removed: {0}", _Queue[_FrontPointer]);
                    Console.WriteLine("Front:{0}", _FrontPointer);
                    Console.WriteLine("Rear:{0}", _RearPointer);
                    return _Queue[_FrontPointer++];
                }
            }

            public T Peek()
            {
                T Item;
                if (IsEmpty)
                    throw new Exception();
                else
                    Item = _Queue[_FrontPointer];
                return Item;
            }

            /*public void PrintAll()
            {
                if (IsEmpty == true)
                {
                    Console.WriteLine("Queue is empty");
                }
                else
                {
                    for (int i = _FrontPointer; i <= _RearPointer; i++)
                    {
                        Console.WriteLine("Item: {0}\nItem position: {1}", _Queue[i], i);
                    }

                }
            }*/

        }

        class CQueue<T> : LQueue<T>
        {
            public CQueue()
            {
                _RearPointer = -1;
                _FrontPointer = 0;
            }

            public override T RemoveItem()
            {
                if (_RearPointer + 1 % 5 == _FrontPointer)
                {
                    _RearPointer = -1;
                    _FrontPointer = 0;
                }
                return base.RemoveItem();
            }

            public override bool IsFull
            {
                get
                {
                    if (QueueSize == _MAX - 1)
                        return true;
                    else
                        return false;
                }
            }

            public override bool IsEmpty
            {
                get
                {
                    if (_QueueSize == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public int QueueSize
            {
                get
                {
                    _QueueSize = (_RearPointer - _FrontPointer) + 1;
                    //
                    return _QueueSize;
                }
            }

            /*public void AddItem(T inItem)
            {
                if (IsFull == false)
                {
                    _Queue[++_RearPointer] = inItem;
                    Console.WriteLine(_Queue[_RearPointer]);
                    _RearPointer++;

                }
                else
                {
                    Console.WriteLine("Queue full");
                }
            }

            /*public T RemoveItem()
            {
                Console.WriteLine("Removed: {0}", _Queue[_FrontPointer]);
                _FrontPointer++;
                return _Queue[_FrontPointer];
            }*/
        }

        static void Main(string[] args)
        {
            const int MAX = 5;

            int UserInput = -1;
            string ItemToBeAdded;
            CQueue<string> CirQueue = new CQueue<string>();
            LQueue<string> LinearQ = new LQueue<string>();
            while (UserInput != 0)
            {
                Console.WriteLine("0, Exit");
                Console.WriteLine("1, Add item");
                Console.WriteLine("2, Remove item");
                Console.WriteLine("3, Peek");
                //Console.WriteLine("3, Print all items in queue");

                UserInput = int.Parse(Console.ReadLine());


                switch (UserInput)
                {
                    case 1:
                        Console.WriteLine("Enter item to be added:");
                        ItemToBeAdded = Console.ReadLine();
                        CirQueue.AddItem(ItemToBeAdded);
                        //LinearQ.AddItem(ItemToBeAdded);
                        break;
                    case 2:
                        CirQueue.RemoveItem();
                        //LinearQ.RemoveItem();

                        break;
                    case 3:
                        CirQueue.Peek();
                        break;
                }
            }
        }
    }
}
