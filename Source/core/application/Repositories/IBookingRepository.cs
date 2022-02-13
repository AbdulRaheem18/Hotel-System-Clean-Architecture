using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Management_System.Model;

namespace application.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Booking> GetByHotelId(Guid hotelId);

        

    }
}