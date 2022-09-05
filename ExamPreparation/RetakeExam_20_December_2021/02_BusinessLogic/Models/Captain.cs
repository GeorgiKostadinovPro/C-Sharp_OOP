namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private readonly ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.CombatExperience = 0;
            this.vessels = new List<IVessel>();
        }
        public string FullName
        {
            get => this.fullName;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                this.fullName = value; 
            }
        }

        public int CombatExperience
        {
            get => this.combatExperience;
            private set
            {
                if (value % 10 == 0)
                {
                    this.combatExperience = value;
                }
            }
        }

        public ICollection<IVessel> Vessels => this.vessels;


        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            if (this.vessels.All(x => x.Name != vessel.Name))
            {
                this.vessels.Add(vessel);
            }
            
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            if (this.Vessels.Count == 0)
            {
                return $"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            foreach (var vs in this.Vessels)
            {
                sb.AppendLine(vs.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
