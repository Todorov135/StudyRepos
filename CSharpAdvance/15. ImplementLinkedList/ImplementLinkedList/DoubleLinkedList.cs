using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ImplementLinkedList
{
    public class DoubleLinkedList
    {
        public class Node
        {
           
            public Node(int element)
            {
                this.Value = element;
            }

            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        public int Count { get; private set; }
        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public bool IsEmpty => this.Count == 0;

        public void AddFirst(int value) 
        {
            if (IsEmpty)
            {
                this.Head = this.Tail = new Node(value);
            }
            else
            {
                Node previosHead = this.Head;
                Node newNode = new Node(value);
                previosHead.Previous = newNode;
                newNode.Next = previosHead;
                this.Head = newNode;
            }
            this.Count++;
        }
        public void AddLast(int value)
        {
            if (IsEmpty)
            {
                this.Head = this.Tail = new Node(value);
            }
            else
            {
                Node previosTail = this.Tail;
                Node newTail = new Node(value);
                newTail.Previous = previosTail;
                previosTail.Next = newTail;
                this.Tail = newTail;
            }
            this.Count++;
        }
        public int RemoveHead() 
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Cannot remove head because the list is empty.");
            }
            Node removedHead = this.Head;
            int removedHeadValue = removedHead.Value;
            Node nextHead = removedHead.Next;
            if (nextHead == null)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                nextHead.Previous = null;
                removedHead.Next = null;
                this.Head = nextHead;
            }
            this.Count--;
            return removedHeadValue;
        }
        public int RemoveTail()
        {

            if (IsEmpty)
            {
                throw new InvalidOperationException("Cannot remove tail because the list is empty.");
            }
            Node removedTail = this.Tail;
            int removedTailValue = removedTail.Value;
            Node nextTail = removedTail.Previous;
            if (nextTail == null)
            {
                this.Head = this.Tail = null;
            }
            else
            {
                nextTail.Next = null;
                removedTail.Previous = null;
                this.Tail = nextTail;
            }
            this.Count--;
            return removedTailValue;
        }
        public void ForEach(Action<int> action)
        {
            Node currNode = this.Head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }
        public List<int> ToList()
        {
            List<int> list = new List<int>();
            this.ForEach(n => list.Add(n));
            return list;
        }

    }
}
