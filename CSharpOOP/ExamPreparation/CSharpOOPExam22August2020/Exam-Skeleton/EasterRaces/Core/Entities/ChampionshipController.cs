using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.GetByName(driverName);
            var car = this.cars.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            if (!driver.CanParticipate)
            {
                driver.AddCar(car);
                this.cars.Remove(car);
            }
            else
            {
                this.cars.Add(driver.Car);
                driver.AddCar(car);
                this.cars.Remove(car);           
            }
           
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

       

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.GetByName(raceName);
            var driver = this.drivers.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            
           
            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded,driverName,raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }
           
            if (this.cars.GetAll().Where(c=>c.Model == model).Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists,model));
            }
            this.cars.Add(car);
            return string.Format(OutputMessages.CarCreated,car.GetType().Name, model);

        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (this.drivers.GetAll().Where(d=>d.Name == driverName).Any())
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists,driverName));
            }
            this.drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (this.races.GetAll().Where(r=>r.Name == name).Any())
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            this.races.Add(race);
            return string.Format(OutputMessages.RaceCreated,name);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            List<IDriver> fastAndFourousDrivers = new List<IDriver>();
            foreach (IDriver driver in this.drivers.GetAll().Where(d=>d.CanParticipate).OrderByDescending(d=>d.Car.CalculateRacePoints(race.Laps)).Take(3))
            {
                fastAndFourousDrivers.Add(driver);
            }

            if (fastAndFourousDrivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,raceName,3));
            }
            fastAndFourousDrivers[0].WinRace();
            var sb = new StringBuilder();
            sb.AppendLine($"Driver {fastAndFourousDrivers[0].Name} wins {raceName} race.")
              .AppendLine($"Driver {fastAndFourousDrivers[1].Name} is second in {raceName} race.")
              .AppendLine($"Driver {fastAndFourousDrivers[2].Name} is third in {raceName} race.");
            return sb.ToString().Trim();
        }
    }
}
