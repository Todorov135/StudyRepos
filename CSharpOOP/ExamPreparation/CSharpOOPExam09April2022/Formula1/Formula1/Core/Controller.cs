using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.Entity;
using Formula1.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            if (this.pilotRepository.FindByName(fullName) != default)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            IPilot pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (this.carRepository.FindByName(model) != default)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }
            IFormulaOneCar car;
            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            this.carRepository.Add(car);
            return $"Car {type}, model {model} is created.";
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            if(this.raceRepository.FindByName(raceName) != default)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            IRace race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = this.carRepository.FindByName(carModel);
            if (pilot == default || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            if (car == default)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }
            this.carRepository.Remove(car);
            pilot.AddCar(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);
            if (race == default)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (pilot == default || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }
        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race == default)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (race.Pilots.Count< 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            race.TookPlace = true;
            List<IPilot> winners = new List<IPilot>();
            int raceLaps = race.NumberOfLaps;
            foreach (IPilot pilot in race.Pilots.OrderByDescending(p=>p.Car.RaceScoreCalculator(raceLaps)))
            {
                winners.Add(pilot);
            }
            winners[0].WinRace();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {winners[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {winners[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {winners[2].FullName} is third in the {raceName} race.");
            return sb.ToString().TrimEnd();
        }
        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRace race in this.raceRepository.Models.Where(r=>r.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }
        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IPilot pilot in this.pilotRepository.Models.OrderByDescending(p=>p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
