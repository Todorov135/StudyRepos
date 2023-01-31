using System;

namespace ImplementLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList newList = new DoubleLinkedList();
            newList.AddFirst(1);
            newList.AddFirst(2);
            newList.AddFirst(3); // head
            newList.AddLast(4); // tail

            Console.WriteLine(newList.Head.Value);
            Console.WriteLine(newList.Tail.Value);
            Console.WriteLine(newList.Tail.Previous.Value);

        }
    }
}
