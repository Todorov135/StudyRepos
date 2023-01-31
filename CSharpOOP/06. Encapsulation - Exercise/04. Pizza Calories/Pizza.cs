using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxCharsInPizzaName = 15;
        private const int MaxToppingsInPizza = 10;

		private string name;
		private Dough dough;
		private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.Dough = dough;
            
        }
		public string Name
		{
			get
            {
                return name;
            }
			private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length> MaxCharsInPizzaName)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
		}
        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }
        private List<Topping> ToppingsList
        {
            get
            {
                return toppings;
            }
            set
            {
               
                toppings = value;
            }

        }
        public IReadOnlyCollection<Topping> Toppings
        {
                
            get
            {
                return toppings.AsReadOnly();
            }
        }
        public void AddTopping(Topping topping)
        {
            if (this.ToppingsList.Count > MaxToppingsInPizza)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.ToppingsList.Add(topping);
        }

        public double Calories => this.Dough.Calories + this.ToppingsList.Sum(t=>t.Calories);




    }
}
