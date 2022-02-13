using System.Threading.Tasks;
using application.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Model;
using System;

namespace infrastructure.Persistence
{
    public class FacilitiesRepository : BaseRepository<Facility, AppdbContext>, IFacilitiesRepository
    {
        public FacilitiesRepository(AppdbContext context) : base(context)
        {
        }

        public async Task<Facility> GetByHotelId(int hotelId)
        {
            return await context.Set<Facility>()
             .Where(p => p.hotelId == hotelId)
             .AsNoTracking()
             .FirstOrDefaultAsync();
        }

        
    }
}