using Animals.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Gender
        {
            get
            {
                return this.gender; 
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAnimalInput);
                }

                this.gender = value;
            }
        }


        public int Age
        {
            get 
            {
                return this.age;
            }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAnimalInput);
                }

                this.age = value;
            }
        }


        public string Name
        {
            get 
            {
                return this.name; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAnimalInput);
                }

                this.name = value; 
            }
        }

        public abstract string ProduceSound();


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
