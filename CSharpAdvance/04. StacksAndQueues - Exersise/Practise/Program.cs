using System;
using System.Collections.Generic;
using System.Linq;

namespace Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCounter = 1;
            int sum = 0;
            while (stack.Count>0)
            {
                int currClothe = stack.Peek();
                if (currClothe + sum >= rackCapacity)
                {
                    rackCounter++;
                    sum = 0;
                }
                else
                {
                    sum += currClothe;
                    stack.Pop();
                }
               
            }
            Console.WriteLine(rackCounter);
        }
    }
}
