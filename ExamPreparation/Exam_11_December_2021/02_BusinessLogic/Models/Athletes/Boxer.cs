using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int BoxerInitialStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, BoxerInitialStamina)
        {
        }

        public override void Exercise()
        {
            int increasedStamina = this.Stamina + 15;

            if (increasedStamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            this.Stamina = increasedStamina;
        }
    }
}
