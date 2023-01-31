using System.Security.Cryptography.X509Certificates;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
  
    public class Bus : Vehicles , IEmptyBus
    {
        private const double BusWithPeopleConsumption = 1.4;

        public Bus(double fuelQuntity, double fuelConsumption, double tankCapacity) : base(fuelQuntity, fuelConsumption, tankCapacity)
        {
        }

         public override double FuelModifiere => BusWithPeopleConsumption;

        public string DriveEmpty(double distance)
        {
            if (base.FuelQuantity - (distance * (base.FuelConsumption- BusWithPeopleConsumption)) >= 0)
            {
                base.FuelQuantity -= (distance * (base.FuelConsumption - BusWithPeopleConsumption));
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

    }
}
