using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories.Entity
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> models;
        public BookingRepository()
        {
            this.models = new List<IBooking>();
        }
        public void AddNew(IBooking model) => this.models.Add(model);

        public IReadOnlyCollection<IBooking> All() => this.models.AsReadOnly();

        public IBooking Select(string criteria) => this.models.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria));
       
    }
}
