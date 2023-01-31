using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var count = new Dictionary<double, int>();
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                double currDigit = input[i];
                if (!count.ContainsKey(currDigit))
                {
                    count.Add(currDigit, 1);
                }
                else
                {
                    count[currDigit]++;
                }

            }
            foreach (var counted in count)
            {
                Console.WriteLine($"{counted.Key} - {counted.Value} times");
            }
        }
    }
}
