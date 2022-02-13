using System.Threading.Tasks;
using System.Threading;

using tests.application.mocks;
using Xunit;
using AutoMapper;
using application.Profiles;
using application.Features.Hotels.Querries;

namespace applicationTest.querries
{
    public class GetHotel
    {
        private GetHotelByIdHandler Init(){           
            return new GetHotelByIdHandler(
                HotelMock.HotelRepositoryRepo.Object,MapperSetup.Mapper); 
        }


        [Fact]
        public async Task get_status_success(){            
            var _handler = Init();
            var request = new GetHotelByIdRequest{
               Id = HotelMock.Hotel1.HotelId
            };
            var sut = await _handler.Handle(request,CancellationToken.None);
            Assert.NotNull(sut);
            Assert.True(sut.Success);
        }

       
    }
}