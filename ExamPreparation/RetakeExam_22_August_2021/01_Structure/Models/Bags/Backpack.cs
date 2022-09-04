using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {

        }
        public ICollection<string> Items => throw new NotImplementedException();
    }
}
