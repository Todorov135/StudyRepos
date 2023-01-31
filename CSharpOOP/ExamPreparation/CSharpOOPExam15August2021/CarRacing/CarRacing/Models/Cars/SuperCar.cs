using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        //SuperCar always starts with 80 liters available fuel and 10 liters fuel consumption per race.
        private const double SuperCarFuelAvailable = 80;
        private const double SuperCarFuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, SuperCarFuelAvailable, SuperCarFuelConsumptionPerRace)
        {
        }
    }
}
