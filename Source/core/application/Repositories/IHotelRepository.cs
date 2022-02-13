using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Management_System.Model;

namespace application.Repositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<Hotel> GetByName(string name);

        Task<Facility> GetFacilities(Guid HotelId);

        List<Hotel> SearchHotel(string search);

    }
}