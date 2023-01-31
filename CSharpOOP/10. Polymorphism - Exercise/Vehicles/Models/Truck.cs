namespace Vehicles.Models
{
    public class Truck : Vehicles
    {
        private const double VehicleSummerConsumptionIncreese = 1.6;
        private const double TruckLosts = 0.95;

        private double fuelConsumption;
        public Truck(double fuelQuntity, double fuelConsumption) : base(fuelQuntity, fuelConsumption)
        {

        }
        public override double FuelModifiere => VehicleSummerConsumptionIncreese;
        public override void Refuel(double amauntOfRefuel)
        {
            base.Refuel(amauntOfRefuel * TruckLosts);
        }
    }
}
