using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Linq;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        // • bakedFoods – List of foods –  foods offered by the restaurant
        // • drinks – List of drinks – the drinks the restaurant offers
        // • tables – List of tables – all tables in the restaurant

        private List<IBakedFood> foods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income;

        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }


        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            else
            {
                return null;
            }
            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            else
            {
                return null;
            }
            this.foods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            else
            {
                return null;
            }
            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> sortedTables = this.tables.Where(t => t.IsReserved != true).ToList();
            var sb = new StringBuilder();
            foreach (Table table in sortedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            decimal totalBill = 0;
            
            foreach (ITable table in this.tables)
            {
                
                totalBill += table.GetBill();
            }
            return $"Total income: {this.income:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = GetTable(tableNumber);
            if (table == null)
            {
                return null;
            }
            decimal tableBill = table.GetBill();
            this.income += tableBill;
            table.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {tableBill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.GetTable(tableNumber);
            var drink = this.GetDrink(drinkName, drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            string joinedDrinkNameAndBrand = drinkName + " " + drinkBrand;
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, joinedDrinkNameAndBrand); // possible wrong output
        }

      

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.GetTable(tableNumber);
            var food = this.GetFood(foodName);

            
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

       

        public string ReserveTable(int numberOfPeople)
        {
           
            ITable tableToReserve = this.tables.Where(t => t.Capacity >= numberOfPeople).FirstOrDefault();
            if (tableToReserve == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible,numberOfPeople);
            }
            tableToReserve.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved,tableToReserve.TableNumber,numberOfPeople);
        }
        private IBakedFood GetFood(string foodName)
        {
            return this.foods.FirstOrDefault(f=>f.Name == foodName);
        }
        private IDrink GetDrink(string drinkName, string drinkBrand)
        {
            return this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
        }
        private ITable GetTable(int tableNumber)
        {
            return this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
        }
    }
}
