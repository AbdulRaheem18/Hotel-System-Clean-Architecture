using System;
using System.Threading;
using System.Threading.Tasks;
using application.Features.Hotels.Commands;
using application.Repositories;
using Hotel_Management_System.Model;
using MediatR;

namespace application.Features.Bookings.Commands
{
    public class AddbookingHandler : IRequestHandler<AddBookingRequest, AddBookingResponse>
    {
        private readonly IBookingRepository _repository;
       
        public AddbookingHandler(IBookingRepository repository)
        {
            _repository = repository;
            
        }
        public async Task<AddBookingResponse> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            var result = new AddBookingResponse{RequestId = request.RequestId};
            AddBookingValidator validation = new AddBookingValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var checkExist = await _repository.GetByHotelId(request.id);
                if(checkExist != null){
                     result.Success = false;
                     result.Errors.Add("Hotel already exist");
                     return result;
                }

                var dbResponse = await _repository.Add(
                new Booking
                {
                    BookingId = Guid.NewGuid(),
                    HotelId = request.id,
                    Price = request.Price,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                   
                }) ;
            }
            else
            {
                result.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    result.Errors.Add(error.ErrorMessage);                  
                }
            }
            return result;
        }
    }
}