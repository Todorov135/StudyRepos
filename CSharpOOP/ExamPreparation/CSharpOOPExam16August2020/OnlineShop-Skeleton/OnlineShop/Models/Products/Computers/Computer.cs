using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformanc) : base(id, manufacturer, model, price, overallPerformanc)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }


        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();
        public new double OverallPerformance
        {
            get => overallPerformance;
            set
            {
                if (this.components.Count > 0)
                {
                    this.overallPerformance = this.components.Average(c => c.OverallPerformance);
                }
                else
                {
                    this.overallPerformance = value;
                }
            }
         
        }
        public new decimal Price
        {
            get => price;
            set
            {
                if (this.components.Count > 0)
                {
                    this.price = this.components.Sum(c => c.Price) + this.peripherals.Sum(c => c.Price);
                }
                else
                {
                    this.price = value;
                }
            }

        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (IComponent component in this.components)
            {
                sb.AppendLine($"  {component}");
            }
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.OverallPerformance}):");
            foreach (IPeripheral peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }
            return base.ToString() + Environment.NewLine + sb.ToString().Trim();
        }
        public void AddComponent(IComponent component)
        {
            
            if (this.components.Contains(component))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, component.Id));
            }
                this.components.Add(component);
          
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, peripheral.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent componentToRemove = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (componentToRemove is null || this.components.Count == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, componentToRemove.Id)); 
            }
            
            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheralToRemove = this.peripherals.FirstOrDefault(p=>p.GetType().Name == peripheralType);
            if (peripheralToRemove is null|| this.peripherals.Count ==0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType(), peripheralToRemove.Id)) ;
            }
            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }
    }
}
