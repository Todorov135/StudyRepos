using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterInput = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] flourInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(waterInput);
            Stack<double> flour = new Stack<double>(flourInput);

            Dictionary<string, int> products = new Dictionary<string, int>() 
            {
                {"Croissant", 0},
                { "Muffin", 0},
                { "Baguette",0},
                { "Bagel", 0}
            };
            Dictionary<string, double> consistation = new Dictionary<string, double>()
            {
                {"Croissant", 0.5},
                { "Muffin", 0.4},
                { "Baguette",0.3},
                { "Bagel", 0.2}
            };


            while (water.Count > 0 && flour.Count>0)
            {
                double currWater = water.Peek();
                double currFlour = flour.Peek();
                double sumForCalculation = Math.Round(currWater / (currWater + currFlour), 2);
                //double waterAmaunt = currWater / sumForCalculation;
                if (consistation["Croissant"] == sumForCalculation)
                {
                    products["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (consistation["Muffin"] == sumForCalculation)
                {
                    products["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (consistation["Baguette"] == sumForCalculation)
                {
                    products["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (consistation["Bagel"] == sumForCalculation)
                {
                    products["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double neededForCroissant = currWater;
                    double flourToReturn = currFlour - neededForCroissant;
                    products["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(flourToReturn);
                }
                

            }
            products = products.OrderByDescending(v => v.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, v => v.Value);
            foreach (var product in products)
            {
                if (product.Value != 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }
            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}
