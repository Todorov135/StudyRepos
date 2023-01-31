using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;
        public StackOfStrings()
        {
            this.Stack = new Stack<string>();
        }

        public Stack<string> Stack { get; set; }

        public bool IsEmpty()
        {
            if (this.Stack.Count>0)
            {
                return false;
            }
            return true;
        }
        public Stack<string> AddRange(params string[] input)
        {
            foreach (var item in input)
            {
                this.Stack.Push(item);
            }
            return this.Stack;
           
        }
       
    }
}
