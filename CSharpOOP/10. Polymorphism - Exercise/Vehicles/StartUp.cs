using Vehicles.Models;

namespace Vehicles
{
using System;
using Factories;
using Factories.Interfaces;
using Models;
    using Vehicles.Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicles car = vehicleFactory.CreateVehicle(carInput[0], double.Parse(carInput[1]), double.Parse(carInput[2]));
            Vehicles truck = vehicleFactory.CreateVehicle(truckInput[0], double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
