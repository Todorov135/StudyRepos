namespace Problem01.List
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {

        }

        public List(int capacity)
        {
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            
            get
            {
                IsValidindex(index);
               
                return this.items[index];
            }

            set
            {
                IsValidindex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();

            this.items[this.Count] = item;

            this.Count++;
        }



        public bool Contains(T item)
        {
            if (this.Count == 0)
            {
                return false;
            }
            foreach (var currItem in this.items)
            {
                if (currItem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }




        public int IndexOf(T item)
        {

            if (this.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            IsValidindex(index);
            Grow();
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            if (!this.items.Contains(item))
            {
                return false;
            }
            int index = IndexOf(item);
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count] = default;
            this.Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            IsValidindex(index);
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Grow()
        {
            if (this.Count == this.items.Length)
            {
                var newArray = new T[this.items.Length * 2];
                Array.Copy(this.items, newArray, this.Count);
                this.items = newArray;
            }
        }

        private void IsValidindex(int index)
        {
            if (index < 0 || index >= this.Count)
            {

                throw new IndexOutOfRangeException();
            }
        }
    }
}