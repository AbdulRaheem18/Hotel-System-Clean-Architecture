using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using application.Repositories;
using Moq;
using application.common;
using System.Linq;
using Hotel_Management_System.Model;

namespace tests.application.mocks
{
    public class HotelMock
    {  
        private static Hotel _hotel1 = new Hotel{
                    HotelId = Guid.Parse("845ae4ad-acd0-496e-9074-313f45065768"),
                    Description = "New Hotel",
                    Name = "Hotel",
                    Active = true,
                    Price = 220,
                    };

        private static Hotel _hotel2 = new Hotel
        {
            HotelId = Guid.Parse("945aewad-a3d0-496e-9074-313f45065768"),
            Description = "Secomd Hotel",
            Name = "Hotel 2",
            Active = true,
            Price = 330,
        };


        public static Hotel Hotel1 => _hotel1;
        public static Hotel Hotel2 => _hotel2;
        private static Mock<IHotelRepository> _hotelRepositoryRepo;


        public static  Mock<IHotelRepository> HotelRepositoryRepo => _hotelRepositoryRepo;

     


        static HotelMock(){

            _hotelRepositoryRepo = InitHotelRepositoryRepo();
      
        }

        #region  RaffleDraw
        private static Mock<IHotelRepository> InitHotelRepositoryRepo()
        {
            if (HotelRepositoryRepo is null)
            {
                var mock = new Mock<IHotelRepository>();
                mock.Setup(p => p.Get(_hotel1.HotelId))
                .Returns(Task.Run(() => _hotel1));

                mock.Setup(p => p.Add(_hotel1))
                .Returns(Task.Run(() => _hotel1));

                mock.Setup(p => p.Update(_hotel1))
                .Returns(Task.Run(() => _hotel1));

                mock.Setup(p => p.GetAll())
                .Returns(Task.Run(() => {
                    return (new List<Hotel>() { _hotel1, _hotel2 });
                }));

                mock.Setup(p => p.GetPaged(
                    new BasePagedRequest
                    {
                        PageSize = 50,
                        PageNumber = 0
                    }))
                .Returns(Task.Run(() =>
                PagedList<Hotel>.ToPagedList(
                    (new List<Hotel>() { _hotel1, _hotel2 }).AsQueryable(), 0, 50)
                    ));
                return mock;
            }
            return _hotelRepositoryRepo;
        }


        #endregion



    }
}