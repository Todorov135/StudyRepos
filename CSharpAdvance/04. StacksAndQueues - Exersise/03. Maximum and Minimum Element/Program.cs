using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int linesOfInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesOfInput; i++)
            {
                string cmd = Console.ReadLine();

                if (cmd.StartsWith("1"))
                {
                    int element = int.Parse(cmd.Split()[1]);
                    stack.Push(element);
                }
                else if (cmd.StartsWith("2"))
                {
                    stack.Pop();
                }
                else if (cmd.StartsWith("3"))
                {
                    if (stack.Count<1)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Max()); 
                }
                else if (cmd.StartsWith("4"))
                {
                    if (stack.Count < 1)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
