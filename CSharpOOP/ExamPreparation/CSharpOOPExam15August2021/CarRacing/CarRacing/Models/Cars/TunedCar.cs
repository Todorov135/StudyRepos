using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        //TunedCar always starts with 65 liters available fuel and 7.5 liters fuel consumption per race.
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarFuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, TunedCarFuelAvailable, TunedCarFuelConsumptionPerRace)
        {
        }
        public override void Drive()
        {
            base.Drive();
            base.HorsePower = (int)Math.Round(base.HorsePower * 0.97);
        }
    }
}
