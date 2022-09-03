using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        public SleepyBunny(string name) 
            : base(name, 50)
        {
        }
        public override void Work()
        {
            int decreased = this.Energy - 15;

            if (decreased >= 0)
            {
                this.Energy -= 15;
            }
            else
            {
                this.Energy = 0;
            }
        }
    }
}
