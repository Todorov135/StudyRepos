namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
            }
            public T Element { get; set; }
            public Node Next { get; set; }
        }
        private Node Head { get; set; }
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);
            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                newNode.Next = this.Head;
                this.Head = newNode;
            }
            this.Count++;

        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {

                var node = this.Head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
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

            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            var node = this.Head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;

        }

        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            var oldhead = this.Head;
            this.Head = oldhead.Next;
            this.Count--;
            return oldhead.Element;
        }

        public T RemoveLast()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException();
            }
            if (this.Count == 1)
            {
                this.Count--;
                var singleNodeelement = this.Head.Element;
                this.Head = null;
                return singleNodeelement;
            }
            var node = this.Head;
            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            var elementToReturn= node.Next.Element;
            node.Next = null;
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