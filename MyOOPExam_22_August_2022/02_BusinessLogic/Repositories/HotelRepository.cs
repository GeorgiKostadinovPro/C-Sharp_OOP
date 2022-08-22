using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> models;
        public HotelRepository()
        {
            this.models = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
           this.models.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return (IReadOnlyCollection<IHotel>)this.models;
        }

        public IHotel Select(string criteria)
        {
            return this.models.FirstOrDefault(m => m.FullName == criteria);
        }
    }
}
