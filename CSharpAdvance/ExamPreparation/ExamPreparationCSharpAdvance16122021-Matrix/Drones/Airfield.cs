using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private  string name;
        private int capacity;
        private double landingStrip;

		public Airfield(string name, int capacity, double landingString)
		{
			this.Drones = new List<Drone>();
			this.Name = name;
			this.Capacity = capacity;
			this.LandingStrip = landingString;
		}
        public List<Drone> Drones
        {
            get { return drones; }
            set { drones = value; }
        }
        public  string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Capacity
        {
			get { return capacity; }
			set { capacity = value; }
		}
		public double LandingStrip
        {
			get { return landingStrip; }
			set { landingStrip = value; }
		}

		public int Count => this.Drones.Count;
		private bool Fly(Drone drone)
		{
			if (drone.Available == true)
			{
				return drone.Available = false;
            }
			return true;
		}
        public string AddDrone(Drone drone)
		{
			if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
			{
				return "Invalid drone.";
            }
			if (drone.Range>15 || drone.Range<5)
			{
                return "Invalid drone.";
            }
			if (this.Capacity <= this.Drones.Count)
			{
                return "Airfield is full.";
            }
			this.Drones.Add(drone);
			return $"Successfully added {drone.Name} to the airfield.";

        }
		public bool RemoveDrone(string name)
		{
			Drone droneToRemove = this.Drones.FirstOrDefault(d=>d.Name == name);
			return this.Drones.Remove(droneToRemove);
		}
		public int RemoveDroneByBrand(string brand)
		{
			int removedDrones = this.Drones.RemoveAll(d => d.Brand == brand);
			return removedDrones;

        }
		public Drone FlyDrone(string name)
		{
            Drone droneToFly = this.Drones.FirstOrDefault(d => d.Name == name);
			if (droneToFly != null)
			{
				Fly(droneToFly);
				return droneToFly;
			}
			return null;
        }
		public List<Drone> FlyDronesByRange(int range)
		{
			var sortedDrones = new List<Drone>();
			foreach (var item in this.Drones)
			{
				if (item.Range == range)
				{
					Fly(item);
					sortedDrones.Add(item);
                }

			}
			return sortedDrones;
		}
		public string Report()
		{
			List<Drone> sortedDrones = this.Drones.Where(d => d.Available == true).ToList();
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Drones available at {this.Name}:");
			foreach (Drone drone in sortedDrones)
			{
				sb.AppendLine(drone.ToString());
			}
			return sb.ToString().Trim();
			
        }
		
		



    }
}
