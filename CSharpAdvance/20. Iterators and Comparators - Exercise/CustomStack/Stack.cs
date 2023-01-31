using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public Stack()
        {
            this.Stacker = new List<T>();
        }
      
        public List<T> Stacker { get; set; }

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.Stacker.Add(elements[i]);
            }
        }
        public T Pop()
        {
            if (this.Stacker.Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            T lastElement = this.Stacker[this.Stacker.Count-1];
            this.Stacker.RemoveAt(this.Stacker.Count - 1);
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Stacker.Count- 1; i >= 0; i--)
            {
                yield return this.Stacker[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
