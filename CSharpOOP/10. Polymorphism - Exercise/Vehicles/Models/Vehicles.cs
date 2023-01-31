namespace Vehicles.Models
{
    public abstract class Vehicles
    {
		private double fuelQuantity;
		private double fuelConsumption; //in liters

        private Vehicles()
        {
            this.FuelModifiere = 0;
        }
        public Vehicles(double fuelQuntity, double fuelConsumption):this ()
        {
            this.FuelQuantity = fuelQuntity;
            this.FuelConsumption = fuelConsumption;
        }
		
		public double FuelQuantity
        {
			get { return fuelQuantity; }
			private set { fuelQuantity = value; }
		}
        public  double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + this.FuelModifiere; }
        }
        public virtual double  FuelModifiere { get; }

        public virtual string Drive(double distance)
        {
            if (this.FuelQuantity - (distance * this.FuelConsumption) >=0)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }
        public virtual void Refuel(double amauntOfRefuel)
        {
            this.FuelQuantity += amauntOfRefuel;
        }

    }
}
