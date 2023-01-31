using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicles
    {
        private const double VehicleSummerConsumptionIncreese = 0.9; 
                        
        public Car(double fuelQuntity, double fuelConsumption, double tankCapacity) : base(fuelQuntity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelModifiere => VehicleSummerConsumptionIncreese;
    }
}
