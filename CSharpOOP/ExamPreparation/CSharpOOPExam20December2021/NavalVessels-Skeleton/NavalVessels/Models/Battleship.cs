using NavalVessels.Models.Contracts;
using System;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialSrmorThickness = 300;


        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialSrmorThickness)
        {
            
        }
        public bool SonarMode
        {
            get
            {
                return this.sonarMode;
            }
            private set
            {
                
                this.sonarMode = value;
            }
        }

        public override void RepairVessel()
        {
            base.ArmorThickness = InitialSrmorThickness;
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {

                base.MainWeaponCaliber -= 40;

                base.Speed += 5;
                this.SonarMode = false;
            }
            else
            {
                base.MainWeaponCaliber += 40;

                base.Speed -= 5;
                this.SonarMode = true;
            }
        }
        public override string ToString()
        {
            string printSonarMode = this.SonarMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {printSonarMode}";
        }

    }
}
