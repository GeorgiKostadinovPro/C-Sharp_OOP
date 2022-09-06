using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName
        { 
            get 
            {
                return fullName;
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; } = false;

        public void AddCar(IFormulaOneCar car)
        {
            if (car == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
            }

            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
