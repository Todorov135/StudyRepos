using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
		private const double MaxToppingGrams = 50.00;

		private Dictionary<string, double> toppingInfo = new Dictionary<string, double>()
		{
			{ "meat", 1.2},
			{ "veggies", 0.8},
			{ "cheese", 1.1},
			{ "sauce", 0.9}
		};

		private string toppingType;
		private double grams;
		public Topping(string topping, double grams)
		{
			this.ToppingType = topping;
			this.Grams = grams;
				
		}
		public string ToppingType
		{
			get 
			{ 
				return toppingType;
			}
			private set
			{
				if (!toppingInfo.ContainsKey(value.ToLower()))
				{
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
				}
				toppingType = value;
			}
		}
        public double Grams
        {
            get 
			{
				return grams;
			}
            private set
			{
				if (value < 1 || value > MaxToppingGrams)
				{
					throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
				}
				grams = value;
			}
        }

		

		public double Calories => 2 * toppingInfo[this.ToppingType.ToLower()] * this.Grams;




    }
}
