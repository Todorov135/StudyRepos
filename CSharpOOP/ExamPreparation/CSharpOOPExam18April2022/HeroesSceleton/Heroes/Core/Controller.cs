using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    internal class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            this.Heroes = new HeroRepository();
            this.Weapons = new WeaponRepository();
        }
        public HeroRepository Heroes 
        {
            get
            {
                return this.heroes;
            }
            set
            {
                this.heroes = value;
            }
        }
        public WeaponRepository Weapons
        {
            get
            {
                return this.weapons;
            }
            set
            {
                this.weapons = value;
            }
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.Heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            IHero currHero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };
            this.Heroes.Add(currHero);
            string printHeroCreatingMessage = type == typeof(Knight).Name ? $"Successfully added Sir {name} to the collection." : $"Successfully added Barbarian { name} to the collection.";
            return printHeroCreatingMessage;


        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.Weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            IWeapon currWeapon = null;
            if (type == typeof(Mace).Name)
            {
                currWeapon = new Mace(name, durability);
            }
            else if (type == typeof(Claymore).Name)
            {
                currWeapon = new Claymore(name, durability);
            }
            else if (currWeapon == null)
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            this.Weapons.Add(currWeapon);
            string printWeaponCreatingMessage = $"A {currWeapon.GetType().Name.ToLower()} {name} is added to the collection.";
            return printWeaponCreatingMessage;
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon currWeapon = this.Weapons.FindByName(weaponName);
            if (currWeapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            IHero currHero = this.Heroes.FindByName(heroName);
            if (currHero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (currHero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            currHero.AddWeapon(currWeapon);
            this.Weapons.Remove(currWeapon);
            string printAMessageForSuccessAddingWeapon = $"Hero {heroName} can participate in battle using a {currWeapon.GetType().Name.ToLower()}.";
            return printAMessageForSuccessAddingWeapon;

        }


        public string HeroReport()
        {
            ICollection<IHero> sortedheroes = 
                this.Heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (IHero hero in sortedheroes)
            {
                string currWeaponName = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";

                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                .AppendLine($"--Health: {hero.Health}")
                .AppendLine($"--Armour: {hero.Armour}")
                .AppendLine($"--Weapon: {currWeaponName}");
                
            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            List<IHero> heroesToFight = this.Heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(heroesToFight);
        }
    }
}
