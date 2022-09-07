using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;
        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {hero.Name} is well-armed.");
            }

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);

            return $"Hero {hero.Name} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heroes.FindByName(name);

            if (hero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
            }
            else 
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            this.heroes.Add(hero);

            return hero.GetType().Name == "Knight" ? $"Successfully added Sir {name} to the collection." 
                : $"Successfully added Barbarian {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = this.weapons.FindByName(name);

            if (weapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            this.weapons.Add(weapon);

            return $"A {weapon.GetType().Name.ToLower()} {weapon.Name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                string weaponOrNo = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";
                sb.AppendLine($"--Weapon: {weaponOrNo}");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();

            var heroes = this.heroes.Models.Where(h => h.IsAlive == true && h.Weapon != null).ToList();

            string result = map.Fight(heroes);

            return result;
        }
    }
}
