using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;
        public Box()
        {
            this.Elements = new List<T>();
        }

        public List<T> Elements { get; private set; }
        public int Count
        {
            get { return this.Elements.Count; }
        }

        public void Add(T element)
        {
            
            this.Elements.Add(element);
        }
        public T Remove() 
        {
            if (this.Elements.Count == 0)
            {
                throw  new InvalidOperationException("The box is empty!");
            }
            int lastIndex = this.Elements.Count-1;
            T itemOnIndex = this.Elements[this.Elements.Count - 1];
            this.Elements.RemoveAt(lastIndex);
            return itemOnIndex;
        }

    }
}
