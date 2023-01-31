namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
            }
            public T Element { get; private set; }
            public Node Next { get;  set; }
            public Node Previous { get;  set; }
        }
        private Node Head { get;  set; }
        private Node Tail { get;  set; }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            //{ 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };
            var itemToAdd = new Node(item);
            if (this.Count == 0)
            {
                this.Head = this.Tail = itemToAdd;
            }
            else 
            {
                var oldHead = this.Head;
                oldHead.Previous = itemToAdd;
                itemToAdd.Next = oldHead;
                this.Head = itemToAdd;
            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            var itemToAdd = new Node(item);
            if (this.Count == 0)
            {
                this.Head = this.Tail = itemToAdd;
            }
            else
            {
                var oldTaile = this.Tail;
                oldTaile.Next = itemToAdd;
                itemToAdd.Previous = oldTaile;
                this.Tail = itemToAdd;
               
            }
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            return this.Head.Element;
        }

        public T GetLast()
        {
            if (this.Tail == null)
            {
                throw new InvalidOperationException();
            }
            return this.Tail.Element;
        }

        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Count == 1)
            {
                T elementToReturn = this.Head.Element;
                this.Head = this.Tail = null;
                this.Count--;
                return elementToReturn;
            }
            var headToRemove = this.Head;
            T valueToReturn = headToRemove.Element;
            var newHead = this.Head.Next;
            this.Head = newHead;
            newHead.Previous = null;
            this.Count--;
            return valueToReturn;

        }

        public T RemoveLast()
        {
            if(this.Tail == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Count == 1)
            {
                T valueToReturn = this.Tail.Element;
                this.Head = this.Tail = null;
                this.Count--;
                return valueToReturn;
            }
            var tailToRemove = this.Tail;
            var newTail = this.Tail.Previous;
            T elementToReturn = tailToRemove.Element;
            this.Tail = newTail;
            newTail.Next = null;
            this.Count--;
            return elementToReturn;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.Head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


    }
}