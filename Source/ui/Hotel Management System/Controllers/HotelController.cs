using application.Features.Bookings.Commands;
using application.Features.Hotels.Querries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<HotelController>
        [HttpGet]
        public  async Task<SearchResponse> GetHotelslistAsync([FromRoute] SearchRequest id,CancellationToken ct)
        {
            var result = await _mediator.Send(new SearchRequest(),ct);
            return result;
        }

        [HttpGet]
        public async Task<GetHotelByIdResponse> GetHotelDetails([FromRoute] Guid id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetHotelByIdRequest() {
                Id = id
            }, ct);
            return result;
        }

        [HttpGet]
        public async Task<SearchResponse> SearchHotel([FromRoute] string text, CancellationToken ct)
        {
            
            var result = await _mediator.Send(new SearchRequest()
            {
                search = text
            }, ct);
            return result;
        }

        [HttpPost]
        public async Task<AddBookingResponse> BookHotel([FromRoute] AddBookingRequest bookingRequest, CancellationToken ct)
        {
            var result = await _mediator.Send(bookingRequest,ct);
            return result;
        }

      
    }
}
