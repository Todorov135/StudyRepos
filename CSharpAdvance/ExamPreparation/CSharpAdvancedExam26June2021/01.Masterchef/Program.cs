using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> dishesFreshnessLevel = new Dictionary<string, int>()
            {
                { "Dipping sauce" , 150},
                { "Green salad", 250},
                { "Chocolate cake", 300},
                { "Lobster", 400}
            };
            SortedDictionary<string, int> dishesCounter = new SortedDictionary<string, int>()
            {
                { "Dipping sauce" , 0},
                { "Green salad", 0},
                { "Chocolate cake", 0},
                { "Lobster", 0}
            };


            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currIngredients = ingredients.Peek();
                int currFreshness = freshness.Peek();
                if (currIngredients == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (currIngredients * currFreshness == dishesFreshnessLevel["Dipping sauce"])
                {
                    dishesCounter["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currIngredients * currFreshness == dishesFreshnessLevel["Green salad"])
                {
                    dishesCounter["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currIngredients * currFreshness == dishesFreshnessLevel["Chocolate cake"])
                {
                    dishesCounter["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currIngredients * currFreshness == dishesFreshnessLevel["Lobster"])
                {
                    dishesCounter["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    int ingredientsToAdd = currIngredients + 5;
                    ingredients.Enqueue(ingredientsToAdd);
                    ingredients.Dequeue();
                }

            }
            int printHelper = 0;
            foreach (var item in dishesCounter)
            {
                printHelper += item.Value;
            }
            if (printHelper > 3)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            //if (freshness.Any())
            //{
            //    Console.WriteLine($"Freshness left: {freshness.Sum()}");
            //}
            foreach (var item in dishesCounter.OrderByDescending(n => n.Value))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");

                }
            }
        }
    }
}
