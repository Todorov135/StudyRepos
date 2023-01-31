using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private IRepository<IMilitaryUnit> militaryUnits;
        private IRepository<IWeapon> weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            this.militaryUnits = new UnitRepository();
            this.weapons = new WeaponRepository();

            this.Name = name;
            this.Budget = budget;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => Math.Round(SetMilitaryPower(), 3);
        //{
        //    get
        //    {
        //        return this.militaryPower;
        //    }
        //    private set
        //    {
        //        this.militaryPower = SetMilitaryPower();
        //    }
        //}



        public IReadOnlyCollection<IMilitaryUnit> Army => this.militaryUnits.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.militaryUnits.AddItem(unit);
        }


        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string printUnits = this.militaryUnits.Models.Count > 0 ? string.Join(", ", this.militaryUnits.Models.ToList()) : "No units";
            string printWeapons = this.weapons.Models.Count > 0 ? string.Join(", ", this.weapons.Models) : "No weapons";
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            if (this.militaryUnits.Models.Count == 0)
            {
                sb.AppendLine($"--Forces: No units");
            }
            else
            {
                var units = new Queue<string>();

                foreach (var item in this.Army)
                {
                    units.Enqueue(item.GetType().Name);
                }

                sb.AppendLine($"--Forces: {string.Join(", ", units)}");
            }
            if (this.weapons.Models.Count == 0)
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            else
            {
                var weapons = new Queue<string>();
                foreach (var item in this.Weapons)
                {
                    weapons.Enqueue(item.GetType().Name);
                }
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weapons)}");
            }
            sb.Append($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            else
            {
                this.Budget -= amount;
            }
        }

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in this.militaryUnits.Models)
            {
                unit.IncreaseEndurance();
            }
        }
        private double SetMilitaryPower()
        {
            double result = this.militaryUnits.Models.Sum(u => u.EnduranceLevel) + this.weapons.Models.Sum(p => p.DestructionLevel);


            if (this.militaryUnits.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }
            return result;
        }
    }
}
