using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach (char @char in chars)
            {
                if (@char != ' ')
                {
                    if (!count.ContainsKey(@char))
                    {
                        count.Add(@char, 0);
                    }
                    count[@char]++;

                }
            }
            foreach (var @char in count)
            {
                Console.WriteLine($"{@char.Key} -> {@char.Value}");
            }

        }
    }
}
