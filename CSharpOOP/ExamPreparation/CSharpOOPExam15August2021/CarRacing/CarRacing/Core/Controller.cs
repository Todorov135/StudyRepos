﻿using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Models.Racers;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            this.cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar carByVIN = this.cars.FindBy(carVIN);
            if (carByVIN == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            IRacer racer;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, carByVIN);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, carByVIN);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            this.racers.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var orderedRacers = this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username);
            var sb = new StringBuilder();
            foreach (var racer in orderedRacers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
