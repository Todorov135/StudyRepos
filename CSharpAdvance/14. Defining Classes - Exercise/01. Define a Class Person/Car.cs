using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engineSpeed;
        private Engine enginePower;
        private Cargo cargoWeight;
        private Cargo cargoType;
        private Tires tires1Presure;
        private Tires tires1Year;
        private Tires tires2Presure;
        private Tires tires2Year;
        private Tires tires3Presure;
        private Tires tires3Year;
        private Tires tires4Presure;
        private Tires tires4Year;
        public Car(string model, Engine speed, Engine power, Cargo weight, Cargo type, Tires tires1Presure, Tires tires1Year, Tires tires2Presure, Tires tires2Year, Tires tires3Presure, Tires tires3Year, Tires tires4Presure, Tires tires4Year)
        {
            this.Model = model;
            this.EngineSpeed = speed;
            this.EnginePower = power;
            this.CargoWeight = weight;
            this.CargoType = type;
            this.Tires1Presure = tires1Presure;
            this.tires1Year = tires1Year;
            this.tires2Presure = tires2Presure;
            this.tires2Year = tires2Year;
            this.tires3Presure = tires3Presure;
            this.tires3Year = tires3Year;
            this.tires4Presure = tires4Presure;
            this.tires4Year = tires4Year;


        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }
        public Engine EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }
        public Cargo CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }
        public Cargo CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }
        public Tires Tires1Presure
        {
            get { return tires1Presure; }
            set { tires1Presure = value; }
        }
        public Tires Tires1Year
        {
            get { return tires1Year; }
            set { tires1Year = value; }
        }
        public Tires Tires2Presure
        {
            get { return tires2Presure; }
            set { tires2Presure = value; }
        }
        public Tires Tires2Year
        {
            get { return tires2Year; }
            set { tires2Year = value; }
        }
        public Tires Tires3Presure
        {
            get { return tires3Presure; }
            set { tires3Presure = value; }
        }
        public Tires Tires3Year
        {
            get { return tires3Year; }
            set { tires3Year = value; }
        }
        public Tires Tires4Presure
        {
            get { return tires4Presure; }
            set { tires4Presure = value; }
        }
        public Tires Tires4Year
        {
            get { return tires4Year; }
            set { tires4Year = value; }
        }


    }
}
