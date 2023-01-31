using System;

namespace Vehicles.Models
{
    public class Truck : Vehicles
    {
        private const double VehicleSummerConsumptionIncreese = 1.6;
        private const double TruckLosts = 0.95;

        private double fuelConsumption;
        
        public Truck(double fuelQuntity, double fuelConsumption, double tankCapacity) : base(fuelQuntity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelModifiere => VehicleSummerConsumptionIncreese;
        public override void Refuel(double amauntOfRefuel)
        {
            if (amauntOfRefuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            double capacityToFill = this.TankCapacity - this.FuelQuantity;
            if (capacityToFill >= amauntOfRefuel)
            {
                
                base.FuelQuantity += amauntOfRefuel * TruckLosts;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amauntOfRefuel} fuel in the tank");
            }

        }
    }
}
