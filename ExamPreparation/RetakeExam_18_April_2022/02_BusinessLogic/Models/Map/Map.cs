using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players
                .Where(k => k.GetType() == typeof(Knight) && k.IsAlive)
                .ToList();

            List<IHero> barbarians = players
                .Where(b => b.GetType() == typeof(Barbarian) && b.IsAlive)
                .ToList();

            bool continueBattle = true;

            string result = string.Empty;

            while (continueBattle)
            {
                bool allKnightsAreDead = true;
                bool allBarbariansAreDead = true;

                var aliveKnights = 0;
                var aliveBarbarians = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        aliveKnights++;

                        foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            int weaponDamage = knight.Weapon.DoDamage();

                            barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDead = false;
                        aliveBarbarians++;

                        foreach (var knight in knights.Where(k => k.IsAlive))
                        {
                            int weaponDamage = barbarian.Weapon.DoDamage();

                            knight.TakeDamage(weaponDamage);
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    int deathBarbariansCount = barbarians.Count - aliveBarbarians;

                    result = $"The barbarians took {deathBarbariansCount} casualties but won the battle.";
                    break;
                }
                else if (allBarbariansAreDead)
                {
                    int deathKnightsCount = knights.Count - aliveKnights;

                    result = $"The knights took {deathKnightsCount} casualties but won the battle.";
                    break;
                }
            }

            return result;
        }
    }
}
