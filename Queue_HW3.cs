using System;

namespace HW3
{
    class Node
    {
        public Node next;
        public string instruction;
        public string data;

        public Node(string instructionValue, string dataValue)
        {
            instruction = instructionValue;
            data = dataValue;
        }
    }
        class Queue
    {
        private Node Root;

        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }
                ptr.next = node;
            }
        }
        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.next;
            node.next = null;
            return node;
        }
        public Node Get(int index)
        {
            Node node = Root;
            while (index > 0)
            {
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }
                node = node.next;
                index--;
            }
            return node;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue CPUQueue = new Queue();
            string instruction;
            string data;
            int CountCycles = 0;

            do
            {
                instruction = Console.ReadLine();
                if (instruction == "?")
                {
                    break;
                }
                data = Console.ReadLine();
                if (data == "?")
                {
                    break;
                }

                Node CPU = new Node(instruction, data);
                CPUQueue.Push(CPU);
            } while (true) ;
            Node instructionQueue;
            do
            {
                instructionQueue = CPUQueue.Pop();
                if (instructionQueue != null)
                {
                    CountCycles = 2;
                }
                if (instructionQueue == null)
                {
                    break;
                }
            } while (true);

            Console.Clear();
            Console.WriteLine("CPU cycles needed: {0}", CountCycles);
        }
    }
}
