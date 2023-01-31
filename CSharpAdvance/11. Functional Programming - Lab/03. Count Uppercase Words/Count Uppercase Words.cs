using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main()
        {
            
            Predicate<string> cheker = n => n[0] == n.ToUpper()[0];
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(w => cheker(w)).ToArray();
            Console.WriteLine(string.Join("\r\n", input));

          
        }
    }
}
