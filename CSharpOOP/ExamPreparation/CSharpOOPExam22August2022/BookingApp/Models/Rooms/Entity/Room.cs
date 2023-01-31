using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingApp.Models.Rooms.Entity
{
    public abstract class Room : IRoom
    {
        private double pricePerNight;
        private int bedCapacity;
        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;

            this.PricePerNight = 0;
        }
        public int BedCapacity
        {
            get
            {
                return this.bedCapacity;
            }
            private set
            {
                this.bedCapacity = value;
            }
        }

        public double PricePerNight
        {
            get
            {
                return this.pricePerNight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
