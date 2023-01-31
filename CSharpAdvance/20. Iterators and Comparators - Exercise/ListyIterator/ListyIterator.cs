using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> storingData;
        private int counter;

        public ListyIterator(params T[] storingData)
        {
            this.StoringData = new List<T>(storingData);
            counter = 0;
        }

        public List<T> StoringData 
        {
            get
            {
                return storingData;
            }
            set
            {
                storingData = value;
            }
        }
        public int Counter { get; set; }

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                this.Counter++;
            }
            return canMove;
        }
        public bool HasNext() => this.Counter < storingData.Count - 1;
        
        public void Print()
        {
            if (this.StoringData.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine($"{this.StoringData[Counter]}");
        }
        public void PrintAll() 
        {
            foreach (T data in this.StoringData)
            {
                Console.Write(data + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T data in this.StoringData)
            {
                yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
