using BorderControl.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : ICitizen
    {
        public Citizen(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
