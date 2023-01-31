using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ChristmasPastryShop.Models.Delicacies.Entity
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;
        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
            this.Price = price;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double Price 
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Price:F2} lv";
        }
    }
}
