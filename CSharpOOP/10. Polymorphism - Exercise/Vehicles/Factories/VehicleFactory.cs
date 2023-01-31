namespace Vehicles.Factories
{
using Factories.Interfaces;
using Models;
using System;
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicles CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicles vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
               vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new ArgumentException();
            }
            return vehicle;
        }
    }
}
