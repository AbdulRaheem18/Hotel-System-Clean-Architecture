using System.Threading.Tasks;
using application.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Model;
using System;

namespace infrastructure.Persistence
{
    public class BookingRepository : BaseRepository<Booking, AppdbContext>, IBookingRepository
    {
        public BookingRepository(AppdbContext context) : base(context)
        {
        }

        public async Task<Booking> GetByHotelId(int hotelId)
        {
            return await context.Set<Booking>()
             .Where(p => p.HotelId == hotelId)
             .AsNoTracking()
             .FirstOrDefaultAsync();
        }

      
    }
}