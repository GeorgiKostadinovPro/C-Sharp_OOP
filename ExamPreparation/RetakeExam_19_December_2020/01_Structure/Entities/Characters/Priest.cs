﻿using System;
using System.Collections.Generic;
using System.Text;
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

            if (character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
