using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residanceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }
        public IRoom Room  {get; private set;}

        public int ResidenceDuration
        {
            get
            {
                return this.residanceDuration;
            }
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                this.residanceDuration = value;
            }
        }

        public int AdultsCount
        {
            get
            {
                return this.adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.childrenCount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber
        {
            get
            {
                return this.bookingNumber;
            }
            private set
            {
                this.bookingNumber = value;
            }
        }

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");
            return sb.ToString().TrimEnd();
        }

        private double TotalPaid() => Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
      
    }
}
