using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Cocktails.Entity;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.Delicacies.Entity;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;
        public Controller()
        {
            this.booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            this.booths.AddModel(booth);
            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = GetBoothByID(boothId);
            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }
            booth.DelicacyMenu.AddModel(delicacy);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = GetBoothByID(boothId);
            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }
            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }
            ICocktail cocktail;
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            booth.CocktailMenu.AddModel(cocktail);
            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }
        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> booths = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .OrderByDescending(b => b.BoothId).ToList();

            if (booths.Count == 0)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            IBooth booth = booths[0];
            booth.ChangeStatus();
            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }
        public string TryOrder(int boothId, string order)
        {
            IBooth booth = GetBoothByID(boothId);
            string[] items = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = items[0];
            string itemName = items[1];
            int countOfTheOrderedPieces = int.Parse(items[2]);
            if (itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen) && itemTypeName != nameof(Hibernation) && itemTypeName != nameof(MulledWine))
            {
                return $"{itemTypeName} is not recognized type!";
            }
            if (!(booth.DelicacyMenu.Models.Any(d => d.Name == itemName)) && !(booth.CocktailMenu.Models.Any(d => d.Name == itemName)))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }
            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                double price = booth.DelicacyMenu.Models.First(c => c.Name == itemName).Price;
                double currentBill = countOfTheOrderedPieces * price;
                booth.UpdateCurrentBill(currentBill);
                return $"Booth {boothId} ordered {countOfTheOrderedPieces} {itemName}!";
            }
            else if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = items[3];
                if (!(booth.CocktailMenu.Models.Any(d => d.Name == itemName && d.Size == size)))
                {
                    return $"There is no {size} {itemName} available!";
                }
                double price = booth.CocktailMenu.Models.First(c => c.Name == itemName && c.Size == size).Price;
                double currentBill = countOfTheOrderedPieces * price;
                booth.UpdateCurrentBill(currentBill);
                return $"Booth {boothId} ordered {countOfTheOrderedPieces} {itemName}!";
            }
            return null;
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = GetBoothByID(boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            return $"Bill {currentBill:f2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = GetBoothByID(boothId);
            return booth.ToString();
        }

        private IBooth GetBoothByID(int boothId)
        {
            return this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
        }
    }
}
