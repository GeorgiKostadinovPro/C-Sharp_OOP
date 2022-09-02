using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double PriestBaseHealth = 50;
        private const double PriestBaseArmor = 25;
        private const double PriestInitialAbilityPoints = 40;

        public Priest(string name) 
            : base(name, PriestBaseHealth, PriestBaseArmor, PriestInitialAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            
            double increasedHealth =  character.Health + this.AbilityPoints;

            if (increasedHealth > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
            else
            {
                character.Health = increasedHealth;
            }
        }
    }
}
