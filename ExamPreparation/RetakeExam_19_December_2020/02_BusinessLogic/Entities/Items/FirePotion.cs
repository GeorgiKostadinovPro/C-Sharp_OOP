using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int FirePotionInitialWeight = 5;

        public FirePotion()
            : base(FirePotionInitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            double reducedHealth = character.Health - 20;

            if (reducedHealth < 0)
            {
                character.Health = 0;
            }
            else
            {
                character.Health = reducedHealth;
            }
        }
    }
}
