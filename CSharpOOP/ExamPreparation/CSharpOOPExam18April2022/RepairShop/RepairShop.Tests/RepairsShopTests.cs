using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void InitiationGarageClasss_Works()
            {
                Garage garage = new Garage("Garage", 3);

                Assert.AreEqual("Garage", garage.Name);
                Assert.AreEqual(3,garage.MechanicsAvailable);
            }
            [Test]
            public void InitiationGarageClasssWithEmptyName_ShouldThrowException()
            {

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage("", 3);

                });
            }
            [Test]
            public void InitiationGarageClasssWithNullName_ShouldThrowException()
            {

                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 3);

                });
            }
            [TestCase(0)]
            [TestCase(-1)]
            public void InitiationGarageClasssWithoutMechanicks_ShouldThrowException(int mechanicks)
            {

                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("Garage", mechanicks);

                }, "At least one mechanic must work in the garage.");
            }
            [Test]
            public void CarsInGarageShouldBeEqualToCount()
            {

                Garage garage = new Garage("Garage", 3);
                Car car1 = new Car("Car1", 2);
                Car car2 = new Car("Car2", 1);
                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.AreEqual(2, garage.CarsInGarage);
            }
            [Test]
            public void AddCarMethod_ShouldWork()
            {

                Garage garage = new Garage("Garage", 3);
                Car car1 = new Car("Car1", 2);
                Car car2 = new Car("Car2", 1);
                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.AreEqual(2, garage.CarsInGarage);
            }
            [Test]
            public void AddCarMethod_ShouldThrowExceptionWhenThereIsNoMechanickAvalible()
            {

                Garage garage = new Garage("Garage", 2);
                Car car1 = new Car("Car1", 2);
                Car car3 = new Car("Car3", 1);
                Car car2 = new Car("Car2", 1);
                garage.AddCar(car1);
                Assert.Throws<InvalidOperationException>(() =>
                {
                garage.AddCar(car2);
                    garage.AddCar(car3);
                }, "No mechanic available.");
            }
            [Test]
            public void FixCarMethod_ShouldWork()
            {

                Garage garage = new Garage("Garage", 3);
                Car car1 = new Car("Car1", 2);
                garage.AddCar(car1);
                garage.FixCar("Car1");                
               
                Assert.AreEqual(0, car1.NumberOfIssues);
            }
            [Test]
            public void FixCarMethod_ShouldReturnRepiredCar()
            {

                Garage garage = new Garage("Garage", 3);
                Car car1 = new Car("Car1", 2);
                garage.AddCar(car1);
                var actual = garage.FixCar("Car1");

                Assert.AreEqual(car1, actual);
            }
            [Test]
            public void FixCarMethod_ShouldThrowExceptionWhenCarModelIsInvalid()
            {

                Garage garage = new Garage("Garage", 3);
                Car car1 = new Car("Car1", 2);
                garage.AddCar(car1);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("InvalidCar");

                }, "The car InvalidCar doesn't exist.");
            }
            [Test]
            public void RemoveFixedCarMethod_ShouldReturnRepiredCar()
            {

                Garage garage = new Garage("Garage", 4);
                Car car1 = new Car("Car1", 2);
                Car car2 = new Car("Car2", 2);
                Car car3 = new Car("Car3", 2);
                Car car4 = new Car("Car4", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.AddCar(car4);
                garage.FixCar("Car1");
                garage.RemoveFixedCar();
                Assert.AreEqual(3, garage.CarsInGarage);
            }
            [Test]
            public void RemoveFixedCarMethod_ShouldThrowExeptionWhenThereIsNoFixedCar()
            {

                Garage garage = new Garage("Garage", 4);
                Car car1 = new Car("Car1", 2);
                Car car2 = new Car("Car2", 2);
                Car car3 = new Car("Car3", 2);
                Car car4 = new Car("Car4", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.AddCar(car4);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }
            [Test]
            public void ReportMethod_ShouldReturnUnfixedCars()
            {

                Garage garage = new Garage("Garage", 4);
                Car car1 = new Car("Car1", 2);
                Car car2 = new Car("Car2", 2);
                Car car3 = new Car("Car3", 2);
                Car car4 = new Car("Car4", 2);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.AddCar(car4);
                garage.FixCar("Car1");
                string expectedResult = "There are 3 which are not fixed: Car2, Car3, Car4.";
                Assert.AreEqual(expectedResult, garage.Report());
            }
        }
    }
}