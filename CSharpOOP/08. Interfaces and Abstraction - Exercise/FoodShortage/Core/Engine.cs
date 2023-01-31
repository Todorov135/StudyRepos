using BorderControl.Models;
using BorderControl.Models.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private List<IBuyer> all;

        public Engine()
        {
            this.all = new List<IBuyer>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] fillRepositoryWithBuyers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = fillRepositoryWithBuyers[0];
                int age = int.Parse(fillRepositoryWithBuyers[1]);
                string thirdArg = fillRepositoryWithBuyers[2];
                if (fillRepositoryWithBuyers.Length == 4)
                {
                    string birthdate = fillRepositoryWithBuyers[3];
                    all.Add(new Citizen(name, age, thirdArg, birthdate));
                }
                else if (fillRepositoryWithBuyers.Length == 3)
                {
                    all.Add(new Rebel(name, age, thirdArg));
                }
            }
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer buyer = all.FirstOrDefault(n=>n.Name == input);
                if (buyer == null)
                {
                    continue;
                }
                buyer.BuyFood();
                
            }
            Console.WriteLine(all.Sum(b=>b.Food));
        }
    } 
}
