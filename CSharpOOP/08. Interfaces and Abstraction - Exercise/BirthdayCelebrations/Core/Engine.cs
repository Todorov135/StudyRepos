using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private List<IBirthdate> all;

        public Engine()
        {
            this.all = new List<IBirthdate>();
           
        }

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] birthdateObjectInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string birthdateObject = birthdateObjectInfo[0];
                if (birthdateObject == "Citizen")
                {
                    string name = birthdateObjectInfo[1];
                    int age = int.Parse(birthdateObjectInfo[2]);
                    string id = birthdateObjectInfo[3];
                    string birthdate = birthdateObjectInfo[4];
                    all.Add(new Citizen(name, age, id, birthdate));
                }
                else if (birthdateObject == "Pet")
                {
                    string name = birthdateObjectInfo[1];
                    string birthdate = birthdateObjectInfo[2];
                    all.Add(new Pet(name, birthdate));

                }
                else
                {
                    continue;
                }
                
            }
            string birthdatePattern = Console.ReadLine();
            string[] selectedBirthdate = all.Where(a => a.Birthdate.Split("/")[2] == birthdatePattern).Select(a => a.Birthdate).ToArray();
            foreach (string birthdate in selectedBirthdate)
            {
                Console.WriteLine(birthdate);
            }


        }
    } 
}
