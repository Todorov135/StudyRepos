namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node(T value)
            {
                this.Element = value;
            }


        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {

            var newNode = new Node(item);
            if (this.top == null)
            {
                this.top = newNode;
            }
            else
            {
                newNode.Next = this.top;
                this.top = newNode;
            }
            this.Count++;
        }



        public T Pop()
        {
            InvalidTopElement();
            var oldTop = this.top;
            this.top = oldTop.Next;
            this.Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            InvalidTopElement();

            return this.top.Element;
        }



        public bool Contains(T item)
        {
            var node = this.top;
            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void InvalidTopElement()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}