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
            string[] busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicles car = vehicleFactory.CreateVehicle(carInput[0], double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            Vehicles truck = vehicleFactory.CreateVehicle(truckInput[0], double.Parse(truckInput[1]), double.Parse(truckInput[2]),double.Parse(truckInput[3]));
            Vehicles bus = vehicleFactory.CreateVehicle(busInput[0], double.Parse(busInput[1]), double.Parse(busInput[2]),double.Parse(busInput[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}
