using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> smallestDigit = n => n.Min();
            Console.WriteLine(smallestDigit(input));
        }
    }
}
