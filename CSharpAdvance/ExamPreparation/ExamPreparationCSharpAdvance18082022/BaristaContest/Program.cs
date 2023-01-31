using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drinksQuantity = new Dictionary<string, int>()
            {
                { "Cortado", 50},
                { "Espresso", 75},
                { "Capuccino", 100},
                { "Americano", 150},
                { "Latte", 200}
            };
            const int ValueToDecreaseMilk = 5;

            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> drinksCounter = new Dictionary<string, int>()
            {
                { "Cortado", 0},
                { "Espresso", 0},
                { "Capuccino", 0},
                { "Americano", 0},
                { "Latte", 0}
            };

            while (coffee.Count >0 && milk.Count >0)
            {
                int currCoffee = coffee.Dequeue();
                int currMilk = milk.Pop();

                int sumOfDrink = currCoffee + currMilk;
                if (sumOfDrink == drinksQuantity["Cortado"])
                {
                    drinksCounter["Cortado"]++;
                }
                else if (sumOfDrink == drinksQuantity["Espresso"])
                {
                    drinksCounter["Espresso"]++;
                }
                else if (sumOfDrink == drinksQuantity["Capuccino"])
                {
                    drinksCounter["Capuccino"]++;
                }
                else if (sumOfDrink == drinksQuantity["Americano"])
                {
                    drinksCounter["Americano"]++;
                }
                else if (sumOfDrink == drinksQuantity["Latte"])
                {
                    drinksCounter["Latte"]++;
                }
                else
                {
                    int newValueOfMilk = currMilk - ValueToDecreaseMilk;
                    if (newValueOfMilk>0)
                    {
                         milk.Push(newValueOfMilk);
                    }
                }
            }
            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            string coffePrint = coffee.Count > 0 ? $"Coffee left: {string.Join(", ", coffee)}" : "Coffee left: none";
            Console.WriteLine(coffePrint);
            string milkPrint = milk.Count > 0 ? $"Milk left: {string.Join(", ", milk)}" : "Milk left: none";
            Console.WriteLine(milkPrint);
            Dictionary<string, int> sortedStoredDrinkData = drinksCounter
                .OrderBy(v => v.Value)
                .ThenByDescending(d => d.Key)
                .ToDictionary(d=>d.Key, v=>v.Value);
            foreach (var drink in sortedStoredDrinkData)
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
               
            }
        }
    }
}
