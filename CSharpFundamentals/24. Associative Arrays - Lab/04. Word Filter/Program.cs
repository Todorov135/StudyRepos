using System;
using System.Linq;

namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            string[] transformedArray = words.Where(w => w.Length % 2 == 0).ToArray();
            foreach (var word in transformedArray)
            {
                Console.WriteLine(word);
            }
        }
    }
}
