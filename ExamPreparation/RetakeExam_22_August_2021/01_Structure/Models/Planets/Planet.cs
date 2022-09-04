using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name)
        {

        }
        public ICollection<string> Items => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();
    }
}
