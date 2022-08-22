using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> models;
        public RoomRepository()
        {
            this.models = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return (IReadOnlyCollection<IRoom>)this.models;
        }

        public IRoom Select(string criteria)
        {
            return this.models.FirstOrDefault(m => m.GetType().Name == criteria);
        }
    }
}
