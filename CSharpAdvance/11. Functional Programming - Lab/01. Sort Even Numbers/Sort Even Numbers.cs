using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(", ", input.Where(x=>x%2==0).OrderBy(x=>x)));
        }
    }
}
