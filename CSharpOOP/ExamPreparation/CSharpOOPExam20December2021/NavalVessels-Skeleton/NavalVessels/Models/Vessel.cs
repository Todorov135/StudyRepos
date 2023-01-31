using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private readonly ICollection<string> targtes;
        public  Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.targtes = new List<string>();
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
          
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
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get
            {
                return this.captain;
            }
             set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainToVessel);
                }
                this.captain = value;
            }
        }
        public double ArmorThickness { get ; set ; }

        public virtual double MainWeaponCaliber { get; protected set; }

        public virtual double Speed { get; protected set; }

        public ICollection<string> Targets => this.targtes;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
        }

        public abstract void RepairVessel();
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            string printingTargets = this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None";

            sb.AppendLine($"- {this.Name}")
              .AppendLine($" *Type: {this.GetType().Name}")
              .AppendLine($" *Armor thickness: {this.ArmorThickness}")
              .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
              .AppendLine($" *Speed: {this.Speed} knots")
              .AppendLine($" *Targets: { printingTargets}");
            return sb.ToString().Trim();
        }
    }
}
