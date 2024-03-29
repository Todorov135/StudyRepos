﻿using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories.Entity
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> models;
        public HotelRepository()
        {
            this.models = new List<IHotel>();
        }
        public void AddNew(IHotel model) => this.models.Add(model);
        public IReadOnlyCollection<IHotel> All() => this.models.AsReadOnly();
        public IHotel Select(string criteria) => this.models.FirstOrDefault(h=>h.FullName == criteria);
       
    }
}
