using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<quantity>[\d]+)\|(?<price>[^|$%.]*?[\d]+.?[\d]+)?\$";

            string inputLine = Console.ReadLine();
            double totalSum = 0;

            while (inputLine != "end of shift")
            {
                Regex match = new Regex(pattern);

                bool isMatch = match.IsMatch(inputLine);
                if (isMatch)
                {
                    string customer = match.Match(inputLine).Groups["customer"].Value;
                    string product = match.Match(inputLine).Groups["product"].Value;
                    int quantity = int.Parse(match.Match(inputLine).Groups["quantity"].Value);
                    double price = double.Parse(match.Match(inputLine).Groups["price"].Value);

                    double sumOfProduct = quantity * price;
                     totalSum += sumOfProduct;
                    Console.WriteLine($"{customer}: {product} - {sumOfProduct:f2}");
                }

                inputLine = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
