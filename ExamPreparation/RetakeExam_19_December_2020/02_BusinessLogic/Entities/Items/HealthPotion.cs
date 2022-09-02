using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HealthPotionInitialWeight = 5;
        public HealthPotion() 
            : base(HealthPotionInitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            double increasedHealth = character.Health + 20;

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
