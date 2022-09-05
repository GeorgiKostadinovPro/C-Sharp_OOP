namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double mainWeaponCaliber;
        private double speed;
        private readonly ICollection<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
            this.captain = null;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain 
        {
            get => this.captain;
            set
            {
                this.captain = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
            }

        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber
        {
            get => this.mainWeaponCaliber;
            protected set
            {
                this.mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get => this.speed;
            protected set
            {
                this.speed = value;
            }
        }

        public ICollection<string> Targets => this.targets;


        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            if (target.ArmorThickness - this.MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0.0;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }

            if (!this.targets.Contains(target.Name))
            {
                this.targets.Add(target.Name);
            }
            
            this.Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            var sb  = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            string targetsResult = this.Targets.Count == 0 ? " *Targets: None" : $" *Targets: {string.Join(", ", this.Targets)}";

            sb.AppendLine(targetsResult);


            return sb.ToString().TrimEnd();
        }
    }
}
