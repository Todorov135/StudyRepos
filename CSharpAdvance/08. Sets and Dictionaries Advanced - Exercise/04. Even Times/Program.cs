using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> intCounter = new Dictionary<int, int>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!intCounter.ContainsKey(input))
                {
                    intCounter.Add(input, 1);
                }
                else
                {
                    intCounter[input]++;
                }
            }
            Console.WriteLine(string.Join("",intCounter.First(x => x.Value % 2 == 0).Key));
        }
    }
}
