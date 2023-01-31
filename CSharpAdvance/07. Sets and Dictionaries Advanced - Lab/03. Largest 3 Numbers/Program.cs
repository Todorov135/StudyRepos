using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();
            Console.WriteLine(String.Join(" ",input.Take(3)));
        }
    }
}
