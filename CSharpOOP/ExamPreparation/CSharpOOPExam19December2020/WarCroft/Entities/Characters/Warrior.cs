using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        //100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorAbilityPoints = 40;
       

        public Warrior(string name) 
            : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (base.IsAlive && character.IsAlive)
            {
                if (!(this.Equals(character)))
                {
                    character.TakeDamage(base.AbilityPoints);
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
