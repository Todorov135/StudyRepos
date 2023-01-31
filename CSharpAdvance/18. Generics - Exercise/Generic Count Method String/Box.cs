using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Boxes
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        private T data;
        private List<T> list;
        public Box(T data)
        {
            this.Data = data;
        }
        public Box(List<T> list)
        {
            this.List = new List<T>(list);
        }

        public T Data { get; private set; }
        public List<T> List { get; private set; }

        public void Swap(int firstIndex, int secondIndex)
        {

            T element = this.List[secondIndex];
            this.List[secondIndex] = this.List[firstIndex];
            this.List[firstIndex] = element;


        }




        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in this.List)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString().TrimEnd();
        }

        public int CompareTo(T other) => Data.CompareTo(other);
        public int CounterElements<T>(List<T> list, T compareor) where T : IComparable =>

             list.Count(element => element.CompareTo(compareor) > 0);
    }



}


