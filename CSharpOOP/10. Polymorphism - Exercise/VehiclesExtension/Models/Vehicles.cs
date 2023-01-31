using System;
using System.Data;
using System.Diagnostics;

namespace Vehicles.Models
{
    public abstract class Vehicles
    {
		private double fuelQuantity;
		private double fuelConsumption; //in liters
        private double tankCapacity;

       

        public Vehicles()
        {
            this.FuelModifiere = 0;
        }
        public Vehicles(double fuelQuntity, double fuelConsumption, double tankCapacity):this ()
        {
            this.FuelQuantity = fuelQuntity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        protected Vehicles(double fuelQuntity, double fuelConsumption)
        {
            FuelQuntity = fuelQuntity;
            this.fuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
			get 
            {
                return fuelQuantity; 
            }
			protected set 
            {
                
               if (this.FuelQuantity > this.TankCapacity)
                {
                    value = 0;
                }
                else
                {
                    fuelQuantity = value; 
                }
            }
		}
        public  double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + this.FuelModifiere; }
        }
        public virtual double  FuelModifiere { get; }
        public double TankCapacity
        {
            get { return tankCapacity; }
           private set { tankCapacity = value; }
        }

        public double FuelQuntity { get; }

        public virtual string Drive(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) >=0)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }
        public virtual void Refuel(double amauntOfRefuel)
        {
            
            if (amauntOfRefuel <=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            double capacityToFill = this.TankCapacity - this.FuelQuantity;
            if (capacityToFill >= amauntOfRefuel)
            {
                this.FuelQuantity += amauntOfRefuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amauntOfRefuel} fuel in the tank");
            }
            
        }

    }
}
