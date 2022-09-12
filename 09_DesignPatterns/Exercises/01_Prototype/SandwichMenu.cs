﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class SandwichMenu
    {
        private readonly IDictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get 
            {
                return this.sandwiches[name];
            }
            set 
            {
                this.sandwiches.Add(name, value);
            }
        }
    }
}
