using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<Vehicle> vehicles = new List<Vehicle>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputToArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeOfVehicle = inputToArray[0];
                string modelOfVehicle = inputToArray[1];
                string colorOfVehicle = inputToArray[2];
                int horsepower = int.Parse(inputToArray[3]);

                Vehicle vehigle = new Vehicle(typeOfVehicle, modelOfVehicle, colorOfVehicle, horsepower);
                vehicles.Add(vehigle);

            }
            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
               
              Console.WriteLine(vehicles.Find(v => v.Model == input));
                
            }
            var carTypeVehicle = vehicles.Where(v => v.TypeOfVehicle == "car").ToList();
            var truckTypeVehicle = vehicles.Where(v => v.TypeOfVehicle == "truck").ToList();
            double totalCarHorsePower = 0;
            double totalTruckHorsePower = 0;

            foreach (Vehicle car in carTypeVehicle)
            {
                totalCarHorsePower += car.HorsePower;
            }
            foreach (var truck in truckTypeVehicle)
            {
                totalTruckHorsePower += truck.HorsePower;
            }

            Console.WriteLine($"Cars have average horsepower of: {totalCarHorsePower/ carTypeVehicle.Count:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {totalTruckHorsePower / truckTypeVehicle.Count:f2}.");



        }

    }

    class Vehicle
    {
        public Vehicle(string typeOfVehicle, string model, string color, int horsePower)
        {
            this.TypeOfVehicle = typeOfVehicle;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            return $"Type: {(this.TypeOfVehicle == "car" ? "Car" : "Truck")}{ Environment.NewLine}"+ 
                   $"Model: {this.Model}{Environment.NewLine}" +
                   $"Color: {this.Color}{Environment.NewLine}" +
                   $"Horsepower: {this.HorsePower}";
        }



    }
}


   
    


