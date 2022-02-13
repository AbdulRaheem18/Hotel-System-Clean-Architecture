using System.Collections.Generic;
using application.Features.Hotels.DTO;
using application.Features.Responses;

namespace application.Features.PeriodTypes.Querries
{
    public class GetPagedHotelResponse:BaseFeaturePagedResponse
    {
        public GetPagedHotelResponse()
        {
            
        }

        public List<Hoteldto> Result {get;set;}
        
    }
}