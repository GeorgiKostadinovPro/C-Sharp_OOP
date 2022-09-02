using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

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
            this.BaseArmor = armor;
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
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else 
                {
                    this.health = this.BaseHealth;
                }
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
                if (value < 0)
                {
                    this.armor = 0;
                }
                else 
                { 
                    this.armor = this.BaseArmor; 
                }          
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

        // possible to be IBag!!!
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
            EnsureAlive();

            double armorLeft = this.Armor - hitPoints;

            this.Armor -= hitPoints;

            if (armorLeft < 0)
            {
                this.Health -= Math.Abs(hitPoints);

                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}