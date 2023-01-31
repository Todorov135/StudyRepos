using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (!counter.ContainsKey(currChar))
                {
                    counter.Add(currChar,1);
                }
                else
                {
                    counter[currChar]++;
                }

            }
            foreach (var symbol in counter)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}
