using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsepower;
        private double cubicCapacity;
        public Engine(int horsepower, double cubicCapacity)
        {
            this.Horsepower = horsepower;
            this.CubicCapacity = cubicCapacity;

        }

        public int Horsepower
        {
            get { return horsepower; }
            set { horsepower = value; }
        }
        public double CubicCapacity 
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }
    }
}
