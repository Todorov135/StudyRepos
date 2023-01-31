using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MuscleCarMinHorsePower = 400;
        private const int MuscleCarMaxHorsePower = 600;
        private const double MuscleCarCubicCentimeters = 5000;
        public MuscleCar(string model, int horsePower) : base(model, horsePower, MuscleCarCubicCentimeters, MuscleCarMinHorsePower, MuscleCarMaxHorsePower)
        {
        }

       
    }
}
