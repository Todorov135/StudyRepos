using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double presure;

        public Tire (int year, double presure)
        {
            this.Year = year;
            this.Presure = presure;
        }

        public int Year 
        {
            get { return year; }
            set { year = value; }
        }
        public double Presure 
        {
            get { return presure; }
            set { presure = value; }
        }
    }
}
