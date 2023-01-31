using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Entity
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;
       
        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
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

        public string Size { get; private set; }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (this.Size == "Large")
                {
                    this.price = value;
                }
                else if (this.Size == "Middle")
                {
                    this.price = Math.Round((value * 2)/3,2);
                }
                else if (this.Size == "Small")
                {
                    this.price = Math.Round((value * 1) / 3, 2);
                }
            }
        }
        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:F2} lv";
        }
    }
}
