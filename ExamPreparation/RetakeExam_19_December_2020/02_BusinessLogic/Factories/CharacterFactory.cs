using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Factories.Contracts;

namespace WarCroft.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        public Character CreateCharacter(string characterType, string characterName)
        {
			Character character;

			if (characterType == nameof(Warrior))
			{
				character = new Warrior(characterName);
			}
			else if (characterType == nameof(Priest))
			{
				character = new Priest(characterName);
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			return character;
		}
    }
}
