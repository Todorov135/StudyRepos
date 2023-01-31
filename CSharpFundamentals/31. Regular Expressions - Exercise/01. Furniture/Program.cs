using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patterns = @">>(?<item>[A-Za-z\s]+)<<(?<price>[0-9]+(.\d+)?)!(?<quantity>\d+)";
            var furniture = new List<string>();
            double totalSum = 0;
            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, patterns);
                if (match.Success)
                {
                    string item = match.Groups["item"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furniture.Add(item);
                    totalSum += price * quantity;
                    
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            furniture.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}
