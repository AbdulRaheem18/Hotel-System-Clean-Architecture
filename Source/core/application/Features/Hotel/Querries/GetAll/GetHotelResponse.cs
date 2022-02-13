using System.Collections.Generic;
using application.Features.Hotels.DTO;
using application.Features.Responses;

namespace application.Features.Hotels.Querries
{
    public class GetHotelResponse : BaseFeatureResponse
    {
        public GetHotelResponse()
        {
            Result = new List<Hoteldto>();
        }

        public List<Hoteldto> Result {get;set;}
        
    }
}