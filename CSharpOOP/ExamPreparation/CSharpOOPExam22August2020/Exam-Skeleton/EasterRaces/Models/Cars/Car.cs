using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Contracts
{
    public abstract class Car : ICar
    {
        private const int NumberOfCharactersInModel = 4;

        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;


        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < NumberOfCharactersInModel)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, NumberOfCharactersInModel));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }


        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps) => this.CubicCentimeters / this.HorsePower * laps;


    }
}
