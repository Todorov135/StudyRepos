using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < lines; i++)
            {
                string[] element = Console.ReadLine().Split();
                for (int j = 0; j < element.Length; j++)
                {
                    elements.Add(element[j]);
                }
            }
            Console.WriteLine(string.Join(" ", elements.OrderBy(x=>x)));
        }
    }
}
