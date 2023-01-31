using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private bool isReserved;
       

        private int capacity;
        private int numberOfPeople;
        private Table()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.isReserved = false;
            
        }
        public Table(int tableNumber, int capacity, decimal pricePerPerson): this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

        }
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value < 0) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved 
        {
            get
            {
                return this.isReserved;
            }
            private set
            {
                this.isReserved = value;
            }
        }


        public decimal Price => this.PricePerPerson * this.NumberOfPeople + foodOrders.Select(x => x.Price).Sum() + drinkOrders.Select(x => x.Price).Sum();

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.NumberOfPeople = 0;
        }

        public decimal GetBill() => this.Price;
     

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
              .AppendLine($"Type: {this.GetType().Name}")
              .AppendLine($"Capacity: {this.Capacity}")
              .Append($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            
                this.NumberOfPeople = numberOfPeople;               
                this.IsReserved = true;
            
        }
    }
}
