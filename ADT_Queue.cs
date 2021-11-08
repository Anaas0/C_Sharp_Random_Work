using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT_Queue
{
    interface IQueue<T>
    {
        bool IsFull { get; }
        bool IsEmpty { get; }
        int Size { get; }
        void Add(T item);
        T Remove();
        T Peek();
    }
    abstract class Queue<T> : IQueue<T>
    {
        public abstract bool IsFull { get; }
        public abstract bool IsEmpty { get; }
        public abstract int Size { get; }
        public abstract void Add(T item);
        public abstract T Remove();
        public abstract T Peek();
    }
    class LinearQueue<T> : Queue<T>
    {
        public const int MAX_SIZE = 5;
        protected T[] _q = new T[MAX_SIZE];
        protected int _front, _rear;
        public LinearQueue()
        {
            _front = 0;
            _rear = -1;
        }
        public override int Size { get { return _rear - _front + 1; } }
        public override bool IsEmpty
        {
            get
            {
                if (Size == 0)
                    return true;
                else
                    return false;
            }
        }
        public override bool IsFull
        {
            get
            {
                if (_rear == MAX_SIZE - 1)
                    return true;
                else
                    return false;
            }
        }
        public override T Remove()
        {
            T item;
            if (IsEmpty)
                throw new Exception();
            else
            {
                item = _q[_front];
                _front++;
            }
            return item;
        }
        public override T Peek()
        {
            T item;
            if (IsEmpty)
                throw new Exception();
            else
                item = _q[_front];
            return item;
        }
        public override void Add(T item)
        {
            if (IsFull)
                throw new Exception();
            else
            {
                _rear++;
                _q[_rear] = item;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> fifo = new LinearQueue<string>();
            string name;
            int choice = -1;

            Console.WriteLine("Queue Test Program");
            do
            {
                Console.WriteLine("\n1. Add an item");
                Console.WriteLine("2. Remove an item");
                Console.WriteLine("3. Peek ahead");
                Console.WriteLine("0. Quit");
                Console.Write("Enter menu option: ");
                try { choice = int.Parse(Console.ReadLine()); }
                catch { choice = -1; }
                switch (choice)
                {
                    case 1:
                        if (fifo.IsFull)
                            Console.WriteLine("Queue is full.");
                        else
                        {
                            Console.Write("Enter name: ");
                            name = Console.ReadLine();
                            fifo.Add(name);
                            Console.WriteLine("{0} added.\nSize = {1}.", name, fifo.Size);
                        }
                        break;
                    case 2:
                        if (fifo.IsEmpty)
                            Console.WriteLine("Queue is empty.");
                        else
                        {
                            name = fifo.Remove();
                            Console.WriteLine("{0} removed.\nSize = {1}.", name, fifo.Size);
                        }
                        break;
                    case 3:
                        if (fifo.IsEmpty)
                            Console.WriteLine("Queue is empty.");
                        else
                        {
                            name = fifo.Peek();
                            Console.WriteLine("{0} is next item.\nSize = {1}.", name, fifo.Size);
                        }
                        break;
                }
            } while (choice != 0);
        }
    }
}