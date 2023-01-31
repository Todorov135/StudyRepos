using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main()
        {
            Func<decimal, decimal> addVat = x => x * (decimal)1.20;
            Func<string, decimal> decimalParse = x => decimal.Parse(x);

            decimal[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(decimalParse).ToArray();
            decimal[] addedVat = input.Select(d => addVat(d)).ToArray();
            foreach (decimal vatedNum in addedVat)
            {
                Console.WriteLine($"{vatedNum:f2}");
            }

        }
    }
}
