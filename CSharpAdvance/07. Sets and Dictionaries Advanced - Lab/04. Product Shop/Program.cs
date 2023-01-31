using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            var shops = new Dictionary<string, Dictionary<string, string>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                string price = tokens[2];

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, string>());
                }
                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, "");
                }
                shops[shop][product] = price;
            }
            
            foreach (var shop in shops.OrderBy(s=>s.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value.TrimEnd('0')}");
                }
            }
        }
    }
}
