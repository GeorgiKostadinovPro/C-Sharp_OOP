using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        public HappyBunny(string name) 
            : base(name, 100)
        {
        }
        public override void Work()
        {
            int decreased = this.Energy - 10;

            if (decreased >= 0)
            {
                this.Energy -= 10;
            }
            else 
            {
                this.Energy = 0;
            }
        }
    }
}
