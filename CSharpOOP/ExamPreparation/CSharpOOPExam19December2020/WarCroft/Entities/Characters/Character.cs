using System;
using System.Threading;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double baseHealth; //base maximum health
        private double health; //current health, can not be higher baseHealth or less than 0.
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = this.BaseHealth;
            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);

                }
                this.name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            protected set { this.baseHealth = value; }
        }


        public double Health
        {
            get { return health; }
            internal set { this.health = value; }
        }


        public double BaseArmor
        {
            get { return baseArmor; }
            private set { this.baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            private set { this.armor = value; }
        }


        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { this.abilityPoints = value; }
        }
        public Bag Bag
        {
            get { return this.bag; }
            private set { this.bag = value; }
        }


        public bool IsAlive { get; set; } = true;

        public virtual void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double currArmour = this.Armor - hitPoints;
            if (currArmour > 0)
            {
                this.Armor = currArmour;
            }
            else
            {
                this.Armor = 0;
                double transferingcurrArmor = -currArmour;
                double currHealth = this.Health - transferingcurrArmor;
                if (currHealth > 0)
                {
                    this.Health = currHealth;
                }
                else
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            Item currItem ;
            if (item.GetType().Name == "HealthPotion")
            {
                currItem = new HealthPotion();
            }
            else if (item.GetType().Name == "FirePotion")
            {
                currItem = new FirePotion();
            }
            else
            {
                throw new InvalidOperationException();
            }
            currItem.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}