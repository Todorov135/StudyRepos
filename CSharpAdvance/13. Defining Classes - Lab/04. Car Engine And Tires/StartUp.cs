using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelqunatity = double.Parse(Console.ReadLine());
            double fuelconsumtion = double.Parse(Console.ReadLine());

            Car firstcar = new Car();
            Car secondcar = new Car(make, model, year);
            Car thirdcar = new Car(make, model, year, fuelqunatity, fuelconsumtion);

            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)

            };
            var engine = new Engine(560, 6300);

            var car = new Car("Lamborgini", "Urus", 2010, 250, 9, engine, tires);
            

        }
    }
}
