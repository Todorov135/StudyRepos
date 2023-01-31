using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;

        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed)
             : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {

        }
        public bool SubmergeMode
        {
            get
            {
                return this.submergeMode;
            }
            private set
            {

                this.submergeMode = value;
            }
        }

        public override void RepairVessel()
        {
            base.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {

                base.MainWeaponCaliber -= 40;
                base.Speed += 4;
                this.SubmergeMode = false;
            }
            else
            {
                base.MainWeaponCaliber += 40;
                base.Speed -= 4;
                this.SubmergeMode = true;
            }
        }
        public override string ToString()
        {
            string printSubmergeMode = this.SubmergeMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {printSubmergeMode}";
        }
    }
}
