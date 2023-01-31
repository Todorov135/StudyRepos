
namespace Vehicles.Factories.Interfaces
{
    using Vehicles.Models;
    public interface IVehicleFactory
    {
    Vehicles CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
