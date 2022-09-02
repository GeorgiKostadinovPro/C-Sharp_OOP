using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using WarCroft.Factories;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly ICollection<Character> characterParty;
		private readonly ICollection<Item> itemPool;

		private readonly CharacterFactory characterFactory;
		private readonly ItemFactory itemFactory;

		public WarController()
		{
			this.characterParty = new List<Character>();
			this.itemPool = new List<Item>();

			this.characterFactory = new CharacterFactory();
			this.itemFactory = new ItemFactory();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string characterName = args[1];

			Character character = this.characterFactory.CreateCharacter(characterType, characterName);

			this.characterParty.Add(character);

			string result = string.Format(SuccessMessages.JoinParty, character.Name);
			return result;
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = this.itemFactory.CreateItem(itemName);

			this.itemPool.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = this.characterParty
				.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = this.itemPool.Last();
			character.Bag.AddItem(item);
			this.itemPool.Remove(item);

			return string.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = this.characterParty
				.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, character.Name, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			Character[] allCharacters = this.characterParty
				.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health)
				.ToArray();

            foreach (var character in allCharacters)
            {
				string isAliveOrDead = character.IsAlive == true ? "Alive" : "Dead";

				sb.AppendLine(string.Format(SuccessMessages.CharacterStats, 
					character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, isAliveOrDead));
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			StringBuilder sb = new StringBuilder();

			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.characterParty
				.FirstOrDefault(c => c.Name == attackerName);

			Character receiver = this.characterParty
				.FirstOrDefault(c => c.Name == receiverName);

            if (attacker == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}

            if (receiver == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

            if (attacker.GetType().Name != nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, receiverName));
			}

			Warrior warrior = (Warrior)attacker;
			warrior.Attack(receiver);

			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, 
				attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = this.characterParty
				.FirstOrDefault(c => c.Name == healerName);

			Character healingReceiver = this.characterParty
				.FirstOrDefault(c => c.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}

			if (healingReceiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

			if (healer.GetType().Name != nameof(Priest))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			Priest priest = (Priest)healer;
			priest.Heal(healingReceiver);

			return string.Format(SuccessMessages.HealCharacter, 
				healer.Name, healingReceiver.Name, healer.AbilityPoints, healingReceiver.Name, healingReceiver.Health);
		}
	}
}
