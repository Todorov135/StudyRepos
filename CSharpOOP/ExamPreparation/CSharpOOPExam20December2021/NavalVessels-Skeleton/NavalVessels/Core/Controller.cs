using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private IRepository<IVessel> vesselRepository;
        private ICollection<ICaptain> capitans;
        public Controller()
        {
            this.vesselRepository = new VesselRepository();
            this.capitans = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain hiredCapitan = new Captain(fullName);
            
            if (this.capitans.Any(c=>c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            this.capitans.Add(hiredCapitan);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vesselRepository.FindByName(name);
            if (vessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vessel.GetType().Name, name);
            }
            IVessel creatingVessel;
            if (vesselType == "Battleship")
            {
                creatingVessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                creatingVessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            this.vesselRepository.Add(creatingVessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }



        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = GetCapitan(selectedCaptainName);
            if (capitans == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            var vessel = this.vesselRepository.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            captain.AddVessel(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }
        public string CaptainReport(string captainFullName)
        {
            var captain = GetCapitan(captainFullName);
            if (captain != null)
            {
                return captain.Report();
            }
            return null;
        }
        public string VesselReport(string vesselName)
        {
            var vessel = this.vesselRepository.FindByName(vesselName);
            if (vessel != null)
            {
                return vessel.ToString();
            }
            return null;
        }
        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vesselRepository.FindByName(vesselName);
            string print;
            if (vessel is Battleship battleship)
            {
                print = string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                battleship.ToggleSonarMode();
            }
            else if (vessel is Submarine submarine)
            {
                print = string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                submarine.ToggleSubmergeMode();
            }
            else
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            return print;
        }
        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vesselRepository.FindByName(vesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = this.vesselRepository.FindByName(attackingVesselName);
            var defender = this.vesselRepository.FindByName(defendingVesselName);
            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (defender == null)
            {
               return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        private ICaptain GetCapitan(string fullName)
        {
            return this.capitans.FirstOrDefault(c => c.FullName == fullName);
        }

    }
}
