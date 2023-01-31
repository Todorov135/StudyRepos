using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories.Entity
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> models;
        public RoomRepository()
        {
            this.models = new List<IRoom>();
        }
        public void AddNew(IRoom model) => this.models.Add(model);
        public IReadOnlyCollection<IRoom> All() => this.models.AsReadOnly();
        public IRoom Select(string criteria) => this.models.FirstOrDefault(r=>r.GetType().Name == criteria);
    }
}
