using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        protected Fish(string name, string species, decimal price)
        {

        }

        public string Name => throw new NotImplementedException();

        public string Species => throw new NotImplementedException();

        public int Size => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();

        public abstract void Eat();
    }
}
