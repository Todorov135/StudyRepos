using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using BookingApp.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;
       
        public Hotel(string fullName, int category)
        {
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();

            this.FullName = fullName;
            this.Category = category;
        }
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                this.category = value;
            }
        }

        public double Turnover => this.Bookings.All().Sum(r=>r.ResidenceDuration * r.Room.PricePerNight);

        public IRepository<IRoom> Rooms 
        {
            get
            {
                return this.rooms;
            }
            private set //<= should by public, this is for test
            {
                this.rooms = value;
            }
        }

        public IRepository<IBooking> Bookings 
        {
            get
            {
                return this.bookings;
            }
             private set //<= should by public, this is for test
            {
                this.bookings = value;
            }
        }
    }
}
