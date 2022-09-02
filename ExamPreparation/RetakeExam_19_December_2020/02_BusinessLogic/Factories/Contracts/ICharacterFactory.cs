using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Factories.Contracts
{
    public interface ICharacterFactory
    {
        Character CreateCharacter(string characterType, string characterName);
    }
}
