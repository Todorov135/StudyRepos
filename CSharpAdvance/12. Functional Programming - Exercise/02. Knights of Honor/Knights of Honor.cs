using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> addSir = n => Console.WriteLine($"Sir {n}");
            input.ToList().ForEach(addSir);
        }
    }
}
