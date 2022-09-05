using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int WeightlifterInitialStamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, WeightlifterInitialStamina)
        {
        }

        public override void Exercise()
        {
            int increasedStamina = this.Stamina + 10;

            if (increasedStamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            this.Stamina = increasedStamina;
        }
    }
}
