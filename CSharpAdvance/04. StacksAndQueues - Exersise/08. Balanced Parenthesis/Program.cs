using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string asd = Console.ReadLine();
            char[] parenthesis = asd.ToCharArray();
            if (parenthesis.Length%2!=0)
            {
                Console.WriteLine("NO");
                return;
            }
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            for (int i = 0; i < parenthesis.Length/2; i++)
            {
                if (parenthesis[i] == '{' || parenthesis[i] == '[' || parenthesis[i] == '(')
                {
                    stack.Push(parenthesis[i]);
                }
            }
            for (int i = parenthesis.Length / 2; i < parenthesis.Length; i++)
            {
                if (parenthesis[i] == '}' || parenthesis[i] == ']' || parenthesis[i] == ')')
                {
                    queue.Enqueue(parenthesis[i]);
                }
            }
            while (stack.Any())
            {
                char currCharStack = stack.Peek();
                char currCharQueue = queue.Peek();
                if (currCharStack == currCharQueue)
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
