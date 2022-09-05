namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;

    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        private const double battleshipArmorThickness = 300.00;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, battleshipArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode
        {
            get => this.sonarMode;
            private set
            {
                this.sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < battleshipArmorThickness)
            {
                this.ArmorThickness = battleshipArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == true)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40.00;
                this.Speed += 5.00;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40.00;
                this.Speed -= 5.00;
            }
        }

        public override string ToString()
        {
            var sonarMode = this.SonarMode == true ? " *Sonar mode: ON" : " *Sonar mode: OFF";

            return base.ToString() + Environment.NewLine + sonarMode;
        }
    }
}
