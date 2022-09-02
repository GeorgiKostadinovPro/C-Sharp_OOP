using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth; 
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints; 
        private Bag bag;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
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
            get 
            {
                return this.name; 
            }
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
            get 
            {
                return this.baseHealth; 
            }
            private set
            { 
                this.baseHealth  = value; 
            }
        }

        public double Health
        {
            get 
            {
                return  this.health; 
            }
            set 
            {
                this.health = value;
            }
        }

        public double BaseArmor
        {
            get 
            { 
                return this.baseArmor;
            }
            private set 
            {
                this.baseArmor = value; 
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                this.armor = value;  
            }
        }

        public double AbilityPoints
        {
            get 
            { 
                return this.abilityPoints; 
            }
            private set 
            { 
                this.abilityPoints = value;
            }
        }

        public Bag Bag
        {
            get 
            { 
                return this.bag; 
            }
            private set 
            { 
                this.bag = value; 
            }
        }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double leftArmor = this.Armor - hitPoints;

            if (leftArmor > 0)
            {
                this.Armor = leftArmor;
            }
            else
            {
                this.Armor = 0;

                double leftHealth = this.Health - Math.Abs(leftArmor);

                if (leftHealth > 0)
                {
                    this.Health = leftHealth;
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
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}