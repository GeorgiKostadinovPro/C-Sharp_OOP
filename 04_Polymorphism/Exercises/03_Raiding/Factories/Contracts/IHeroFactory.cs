using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories.Contracts
{
    public interface IHeroFactory
    {
        BaseHero CreateHero(string type, string name);
    }
}
