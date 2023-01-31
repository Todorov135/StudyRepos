namespace Vehicles.Core
{
    using Models;
    using System;

    public class Engine : IEngine
    {
        private Vehicles car;
        private Vehicles truck;
        public Engine(Vehicles car, Vehicles truck)
        {
            this.Car = car;
            this.Truck = truck;
        }
        public Vehicles Car { get; private set; }
        public Vehicles Truck { get; private set; }

        public void Start()
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string vehicleType = cmd[1];
                double amount = double.Parse(cmd[2]);
                if (action == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.Car.Drive(amount));
                    }
                    else
                    {
                        Console.WriteLine(this.Truck.Drive(amount));
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        this.Car.Refuel(amount);
                    }
                    else
                    {
                        this.Truck.Refuel(amount);
                    }
                }
            }
            Console.WriteLine($"Car: {this.Car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {this.Truck.FuelQuantity:F2}");
       
        }
    }
}
