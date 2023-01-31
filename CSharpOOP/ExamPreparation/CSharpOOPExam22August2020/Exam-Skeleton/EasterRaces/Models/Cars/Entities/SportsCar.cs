using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int SportsCarMinHorsePower = 250;
        private const int SportsCarMaxHorsePower = 450;
        private const double SportsCarCubicCentimeters = 3000;

        public SportsCar(string model, int horsePower) : base(model, horsePower, SportsCarCubicCentimeters, SportsCarMinHorsePower, SportsCarMaxHorsePower)
        {
        }
    }
}
