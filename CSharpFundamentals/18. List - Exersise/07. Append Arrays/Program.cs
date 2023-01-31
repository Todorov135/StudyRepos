using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|').Reverse().ToList();

            var newList = new List<int>();

            foreach (var item in input)
            {
                newList.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
