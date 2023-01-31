using Gym.Core.Contracts;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes.Entity;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Equipment.Entity;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Gyms.Entity;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            this.gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            this.equipment.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if (equipment == default)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            if (athlete.GetType().Name == "Boxer" && gym.GetType().Name == "BoxingGym")
            {
                gym.AddAthlete(athlete);
            }
            else if (athlete.GetType().Name == "Weightlifter" && gym.GetType().Name == "WeightliftingGym")
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                return "The gym is not appropriate.";
            }
            return $"Successfully added {athleteType} to {gymName}.";
        }
        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (IAthlete athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";

        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGym gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        
    }
}
