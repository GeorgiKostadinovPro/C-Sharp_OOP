namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        private const double submarineArmorThicknes = 200.00;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, submarineArmorThicknes)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get => this.submergeMode;
            private set
            {
                this.submergeMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < submarineArmorThicknes)
            {

                this.ArmorThickness = submarineArmorThicknes;
            }
        }


        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == true)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40.00;
                this.Speed += 4.00;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40.00;
                this.Speed -= 4.00;
            }
        }

        public override string ToString()
        {
            var submergeMode = this.SubmergeMode == true ? " *Submerge mode: ON" : " *Submerge mode: OFF";

            return base.ToString() + Environment.NewLine + submergeMode;
        }
    }
}
