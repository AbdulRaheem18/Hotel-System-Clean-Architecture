using application.Features.Hotel.DTO;
using application.Features.Hotels.DTO;
using application.Features.Responses;

namespace application.Features.Hotels.Querries
{
    public class GetHotelByIdResponse:BaseFeatureResponse
    {
        public HotelDetaildto Result{get;set;}
    }
}