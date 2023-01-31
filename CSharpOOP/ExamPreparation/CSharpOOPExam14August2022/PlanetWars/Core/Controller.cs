using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            IPlanet planet = new Planet(name, budget);
            this.planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = GetPlanetByName(planetName);

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            IMilitaryUnit unit = null;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            //else
            //{
            //    throw new InvalidOperationException($"{unitTypeName} still not available!");
            //}

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = GetPlanetByName(planetName);

            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            IWeapon weapon;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = GetPlanetByName(planetName);
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.TrainArmy();
            planet.Spend(1.25);
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attacker = GetPlanetByName(planetOne);
            IPlanet deffender = GetPlanetByName(planetTwo);

            bool attackerHaveNuclearWeapon = attacker.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") ? true : false;
            bool deffenderHaveNuclearWeapon = deffender.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") ? true : false;

            IPlanet winner = null;
            IPlanet loser = null;
            if (attacker.MilitaryPower > deffender.MilitaryPower)
            {
                winner = attacker;
                loser = deffender;
            }
            else if (deffender.MilitaryPower > attacker.MilitaryPower)
            {
                winner = deffender;
                loser = attacker;
            }
            else
            {
                if ((attackerHaveNuclearWeapon && deffenderHaveNuclearWeapon)
                    || !(attackerHaveNuclearWeapon && deffenderHaveNuclearWeapon))
                {
                    attacker.Spend(attacker.Budget / 2);
                    deffender.Spend(deffender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
                else if (attackerHaveNuclearWeapon)
                {
                    winner = attacker;
                    loser = deffender;
                }
                else if (deffenderHaveNuclearWeapon)
                {
                    winner = deffender;
                    loser = attacker;
                }
            }
            if (winner != null && loser != null)
            {
                winner.Spend(winner.Budget / 2);

                double profitFormLoser = loser.Budget / 2;
                double allLoserMilitaryPower = loser.Army.Sum(u => u.Cost) + loser.Weapons.Sum(w => w.Price);
                winner.Profit(profitFormLoser + allLoserMilitaryPower);
                this.planets.RemoveItem(loser.Name);
                
                return $"{winner.Name} destructed {loser.Name}!";
            }
            else
            {
                return OutputMessages.NoWinner;
            }
        }


        public string ForcesReport()
        {
            List<IPlanet> sortedPLanets = this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (IPlanet planet in sortedPLanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }



        private IPlanet GetPlanetByName(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            return planet;
        }

    }
}
