using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    internal class Tomcat : Cat
    {
        private const string TomcatGender = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, TomcatGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
