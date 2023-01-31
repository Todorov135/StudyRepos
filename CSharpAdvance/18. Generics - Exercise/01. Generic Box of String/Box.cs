using System;
using System.Collections.Generic;
using System.Text;

namespace Boxes
{
    public class Box<T>
    {
        private T data;
        public Box(T data)
        {
            this.Data = data;
        }

        public T Data { get; private set; }
        public override string ToString()
        {
            return $"{typeof(T)}: {this.Data}";
        }
    }
    
}
