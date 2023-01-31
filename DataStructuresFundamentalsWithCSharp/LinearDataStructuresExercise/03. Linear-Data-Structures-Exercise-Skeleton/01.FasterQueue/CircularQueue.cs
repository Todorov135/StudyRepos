namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex;
        private int endIndex;
        public CircularQueue(int capacity = 4)
        {
            this.elements = new T[capacity];
        }
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0 )
            {
                throw new InvalidOperationException();
            }
            else
            {
                T elementToReturn = this.elements[this.startIndex];
                this.elements[this.startIndex] = default;
                this.startIndex = (this.startIndex +1 ) % this.elements.Length;
                this.Count--;
                return elementToReturn;
            }
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        private void Grow()
        {
            this.elements = this.CopyElements();
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements()
        {
            var newArr = new T[this.elements.Length * 2];
            
            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];
                
            }
            return newArr;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T elementToReturn = this.elements[this.startIndex];
            return elementToReturn;
        }

        public T[] ToArray()
        {
            var newArr = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[(this.startIndex + i) % this.elements.Length];

            }
            return newArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int currIndex = 0; currIndex < this.Count; currIndex++)
            {
                int index = (this.startIndex + currIndex) % this.elements.Length;
                yield return this.elements[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


    }

}
