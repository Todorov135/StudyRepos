using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, double> productPrice = new Dictionary<string, double>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            string cmd = Console.ReadLine();

            while (cmd != "buy")
            {
                string[] tokens = cmd.Split(' ');
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!productPrice.ContainsKey(product))
                {
                    productPrice.Add(product, price);
                    productQuantity.Add(product, quantity);
                }
                else if(productPrice.ContainsKey(product))
                {
                    productPrice.Remove(product);
                    productPrice.Add(product, price);
                    productQuantity[product] += quantity;

                }

                cmd = Console.ReadLine();

            }
            foreach (var prodPrice in productPrice)
            {
                foreach (var prodQuantity in productQuantity)
                {
                    if (prodPrice.Key == prodQuantity.Key)
                    {
                        Console.WriteLine($"{prodPrice.Key} -> {prodPrice.Value * prodQuantity.Value:f2}");
                    }
                }
            }
        }
    }
}
