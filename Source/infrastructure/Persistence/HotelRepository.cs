using System.Threading.Tasks;
using application.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Model;
using System;
using System.Collections.Generic;

namespace infrastructure.Persistence
{
    public class HotelRepository : BaseRepository<Hotel, AppdbContext>, IHotelRepository
    {
        public HotelRepository(AppdbContext context) : base(context)
        {
        }

       

        public async Task<Hotel> GetByName(string name)
        {
           

            return await context.Set<Hotel>()
             .Where(p => p.Name == name)
             .AsNoTracking()
             .FirstOrDefaultAsync();
        }

        public async Task<Facility> GetFacilities(Guid HotelId)
        {
            return await context.Set<Facility>()
            .Where(p => p.hotelId == HotelId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        public List<Hotel> SearchHotel(string search)
        {
            var items = context.Hotels.Where(x => EF.Functions.Contains(x.Name, search)).ToList();
            return items;
        }
    }
}