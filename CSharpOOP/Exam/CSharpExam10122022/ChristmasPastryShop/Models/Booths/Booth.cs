using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;       
        private double currentBill;
        private double turnover;
        private bool isReserved;
        public Booth(int boothId, int capacity)
        {
            this.DelicacyMenu = new DelicacyRepository();
            this.CocktailMenu = new CocktailRepository();
            this.CurrentBill = 0.00;
            this.Turnover = 0.00;
            this.IsReserved = false;

            this.BoothId = boothId;
            this.Capacity = capacity;   

        }
        public int BoothId { get; private set; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                this.capacity = value;
            }
        }


        public IRepository<IDelicacy> DelicacyMenu { get; private set; }

        public IRepository<ICocktail> CocktailMenu { get; private set; }

        public double CurrentBill
        {
            get
            {
                return this.currentBill;
            }
            private set
            {
                this.currentBill = value;
            }
        }

        public double Turnover
        {
            get
            {
                return this.turnover;
            }
            private set
            {
                this.turnover = value;
            }
        }

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

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:F2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (ICocktail cocktail in this.CocktailMenu.Models)
            {               
                sb.AppendLine($"--{cocktail.ToString()}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach  (IDelicacy delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
