using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knightCollection = new List<Knight>();
            var barbarianCollection = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knightCollection.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarianCollection.Add(barbarian);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid type of hero.");
                    }
                }
                
            }
            var continueBattle = true;
            while (continueBattle)
            {
                bool allKnightAreDead = true;
                bool allBarberiansAreDead = true;

                int aliveKnight = 0;
                int aliveBarbarian = 0;

                foreach (var knight in knightCollection)
                {
                    if (knight.IsAlive)
                    {
                        allKnightAreDead = false;
                        aliveKnight++;
                        foreach (var barberian in barbarianCollection.Where(b => b.IsAlive))
                        {
                            barberian.TakeDamage(knight.Weapon.DoDamage());

                        }
                    }
                    
                }
                foreach (var barbarian in barbarianCollection)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarberiansAreDead = false;
                        aliveBarbarian++;
                        foreach (var knight in knightCollection.Where(k => k.IsAlive))
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                   
                }
                if (allKnightAreDead)
                {

                    return $"The barbarians took {barbarianCollection.Count-aliveBarbarian} casualties but won the battle.";
                }
                if (allBarberiansAreDead)
                {
                    return $"The knights took {knightCollection.Count-aliveKnight} casualties but won the battle.";
                }
            }
            throw new InvalidOperationException("");
           
        }
    }
}
