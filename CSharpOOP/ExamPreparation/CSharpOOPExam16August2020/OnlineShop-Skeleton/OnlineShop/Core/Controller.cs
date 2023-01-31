using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.components.Contains(this.components.Find(c=>c.Id == id)))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            IComputer computerToAdd = this.computers.FirstOrDefault(c=>c.Id == computerId);
            if (computerToAdd == null)
            {
                throw new ArgumentException();
            }
            computerToAdd.AddComponent(component);
            this.components.Add(component);
            return String.Format(SuccessMessages.AddedComponent, componentType,id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            
            IComputer computer = null;
            if (computerType == "Laptop")
            {
                computer = new Laptop(id,manufacturer,model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            if (this.computers.Contains(this.computers.Find(c => c.Id == id)))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            this.computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral currPeripferal;

            if (peripheralType == "Headset")
            {
                currPeripferal = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                currPeripferal = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                currPeripferal = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                currPeripferal = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            if (this.peripherals.Contains(currPeripferal))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            this.peripherals.Add(currPeripferal);
            return String.Format(SuccessMessages.AddedPeripheral,peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
           IComputer currComputer = this.computers.OrderByDescending(c => c.OverallPerformance).FirstOrDefault(c => c.Price <= budget);
            if (currComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            this.computers.Remove(currComputer);
            return currComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            var currComputer = GetComputerByID(id);
            if (currComputer == null)
            {
                throw new ArgumentException();
            }
            this.computers.Remove(currComputer);
            return currComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            var currComputer = GetComputerByID(id);
            if (currComputer == null)
            {
                throw new ArgumentException();
            }
            return currComputer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var currComputer = GetComputerByID(computerId);
            if (currComputer == null)
            {
                throw new ArgumentException();
            }
            currComputer.RemoveComponent(componentType);
            return String.Format(SuccessMessages.RemovedComponent,componentType, currComputer.Components.First(c=>c.GetType().Name == componentType));
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral currPeripherial = GetPeripherialByType(peripheralType);
            IComputer currComputer = GetComputerByID(computerId);

            if (currPeripherial == null)
            {
                throw new ArgumentException();
            }
            if (currComputer == null)
            {
                throw new ArgumentException();
            }
            currComputer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(currPeripherial);

            return String.Format(SuccessMessages.RemovedPeripheral,peripheralType, currPeripherial.Id);
        }

        

        private IComputer GetComputerByID(int computerId)
        {
            return this.computers.FirstOrDefault(c => c.Id == computerId);
        }
        private IPeripheral GetPeripherialByType(string peripheralType)
        {
            return this.peripherals.FirstOrDefault(p=>p.GetType().Name == peripheralType);
        }
    }
}
