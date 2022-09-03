using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        protected Bunny(string name, int energy)
        {

        }
        public string Name => throw new NotImplementedException();

        public int Energy => throw new NotImplementedException();

        public ICollection<IDye> Dyes => throw new NotImplementedException();

        public void AddDye(IDye dye)
        {
            throw new NotImplementedException();
        }

        public abstract void Work();
    }
}
