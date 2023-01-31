using Raiding.Core;
using Raiding.Factories;
using Raiding.Models;
using System;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Raid raid = new Raid();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            int counter = 0;

            
            while (numberOfHeroes != counter)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    HeroFactory heroFactory = new HeroFactory();
                    raid.AddRaidMemeber(heroFactory.CreateHero(name, heroType));
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            Engine engine = new Engine(raid, bossPower);
            engine.Start();




        }
    }
}
