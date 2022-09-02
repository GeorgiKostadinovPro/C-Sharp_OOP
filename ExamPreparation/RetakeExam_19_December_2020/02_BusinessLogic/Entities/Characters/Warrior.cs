﻿using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorInitialAbilityPoints = 40;

        public Warrior(string name)
            : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorInitialAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            
            if (this.Name == character.Name)
            {
               throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            double damagePoints = this.AbilityPoints;
            character.TakeDamage(damagePoints);
        }
    }
}
