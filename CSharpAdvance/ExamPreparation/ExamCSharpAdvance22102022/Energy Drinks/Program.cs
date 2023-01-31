using System;
using System.Collections.Generic;
using System.Linq;

namespace Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaximumCaffeine = 300;
            const int StamatDecreasecaffeineIndex = 30;

            Stack<int> caffeinе = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrink = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int stamatTotalCaffeine = 0;
            while (caffeinе.Count != 0 && energyDrink.Count != 0)
            {
                int currCaffeine = caffeinе.Peek();
                int currEnergyDrink = energyDrink.Peek();
                if (currCaffeine <= 0 || currEnergyDrink <= 0)
                {
                    break;
                }

                int caffeineInDrink = currCaffeine * currEnergyDrink;
                if (caffeineInDrink <= MaximumCaffeine - stamatTotalCaffeine)
                {
                    
                    caffeinе.Pop();
                    energyDrink.Dequeue();
                    stamatTotalCaffeine += caffeineInDrink;
                   
                }
                else
                {
                    caffeinе.Pop();
                    energyDrink.Enqueue(currEnergyDrink);
                    energyDrink.Dequeue();
                    stamatTotalCaffeine -= StamatDecreasecaffeineIndex;
                    if (stamatTotalCaffeine <0)
                    {
                        stamatTotalCaffeine = 0;
                    }
                }
            }
            string printDrinks = energyDrink.Count > 0 ? $"Drinks left: {string.Join(", ", energyDrink)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.";
            Console.WriteLine(printDrinks);
            Console.WriteLine($"Stamat is going to sleep with {stamatTotalCaffeine} mg caffeine.");
        }
    }
}
