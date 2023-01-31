using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Gym.Models.Gyms.Entity
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.equipments = new List<IEquipment>();
            this.athletes = new List<IAthlete>();

            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }
        public ICollection<IEquipment> Equipment => this.equipments;
        public ICollection<IAthlete> Athletes => this.athletes;

        public double EquipmentWeight => SumOfGymEquipmentWeight();


        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == this.Athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            this.Athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }
        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            string printAtletes = this.Athletes.Count > 0 ? string.Join(", ", this.Athletes.Select(a => a.FullName)) : "No athletes";
            sb.AppendLine($"Athletes: {printAtletes}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");
            return sb.ToString().TrimEnd();
        }


        private double SumOfGymEquipmentWeight()
        {
            return this.Equipment.Sum(e => e.Weight);
        }
    }
}
