using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private List<IEnterable> all;

        public Engine()
        {
            this.all = new List<IEnterable>();
           
        }

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenOrRobot = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (citizenOrRobot.Length == 3)
                {
                    string name = citizenOrRobot[0];
                    int age = int.Parse(citizenOrRobot[1]);
                    string id = citizenOrRobot[2];
                    all.Add(new Citizen(name, age, id));
                }
                else if (citizenOrRobot.Length == 2)
                {
                    string model = citizenOrRobot[0];
                    string id = citizenOrRobot[1];
                    all.Add(new Robot(model, id));
                }
            }
            string patternToRemove = Console.ReadLine();
            string[] fakeId = all.Where(a => a.Id.EndsWith(patternToRemove)).Select(a => a.Id).ToArray();
            foreach (string id in fakeId)
            {
                Console.WriteLine(id);
            }

        }
    } 
}
