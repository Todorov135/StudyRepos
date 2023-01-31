using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfParty = int.Parse(Console.ReadLine());
            var party = new List<Hero>();

            for (int i = 0; i < numberOfParty; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int health = int.Parse(input[1]);
                int mana = int.Parse(input[2]);
                Hero hero = new Hero(name, health, mana);
                party.Add(hero);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(" - ");

                string action = tokens[0];
                string heroName = tokens[1];
                Hero hero = party.Find(x => x.Name == heroName);

                if (action == "CastSpell")
                {
                    int manaNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    CastSpell(hero, manaNeeded, spellName);
                }
                else if (true)
                {

                }


                command = Console.ReadLine();
            }
         
        }

        private static void CastSpell(Hero hero, int manaNeeded, string spellName)
        {
            if (hero.Mana >= manaNeeded)
            {
                hero.Mana -= manaNeeded;
                Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mana} MP!");
            }
            else
            {
                Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
            }
        }
    }
    public class Hero
    {
        public Hero(string name, int health, int mana)
        {
            this.Name = name;
            this.Health = health;
            this.Mana = mana;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
    }
}
