using PlanetWars.Core;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using System;

namespace PlanetWars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            // var engine = new Engine();
            //
            // engine.Run();



            var cont = new Controller();


            try
            {
                Console.WriteLine(cont.CreatePlanet("Zemq", 400));
                Console.WriteLine(cont.CreatePlanet("Mars", 350));


                // Console.WriteLine(cont.AddWeapon("Zemq", "NuclearWeapon", 3));
                // Console.WriteLine(cont.AddWeapon("Mars", "NuclearWeapon", 3));

               //Console.WriteLine(cont.AddWeapon("Zemq", "NuclearWeapon", 3));
               //Console.WriteLine(cont.AddWeapon("Mars", "NuclearWeapon", 3));

               //Console.WriteLine(cont.AddWeapon("Zemq", "SpaceMissiles", 3));
               //Console.WriteLine(cont.AddWeapon("Mars", "SpaceMissiles", 3));

                //Console.WriteLine(cont.AddWeapon("Zemq", "SpaceMissiles", 3));
                //Console.WriteLine(cont.AddWeapon("Mars", "NuclearWeapon", 3));

                Console.WriteLine(cont.AddWeapon("Zemq", "NuclearWeapon", 3));
                Console.WriteLine(cont.AddWeapon("Mars", "SpaceMissiles", 3));

                //Console.WriteLine(cont.AddUnit("StormTroopers", "Zemq"));
                Console.WriteLine(cont.AddUnit("StormTroopers", "Mars"));

                Console.WriteLine(cont.AddUnit("AnonymousImpactUnit", "Zemq"));
                Console.WriteLine(cont.AddUnit("AnonymousImpactUnit", "Mars"));

                Console.WriteLine(cont.SpecializeForces("Zemq"));
                
                Console.WriteLine(cont.SpecializeForces("Mars"));

                Console.WriteLine(cont.SpaceCombat("Zemq", "Mars"));

            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }
    }
}
