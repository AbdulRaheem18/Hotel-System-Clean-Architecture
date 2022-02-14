using System;
using System.Threading;
using System.Threading.Tasks;

using application.Repositories;
using Hotel_Management_System.Model;
using MediatR;

namespace application.Features.Hotels.Commands
{
    public class AddbookingHandler : IRequestHandler<AddBookingRequest, AddBookingResponse>
    {
        private readonly IHotelRepository _repository;
       
        public AddbookingHandler(IHotelRepository repository)
        {
            _repository = repository;
            
        }
        public async Task<AddBookingResponse> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            var result = new AddBookingResponse{RequestId = request.RequestId};
            AddBookingValidator validation = new AddHotelValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var checkExist = await _repository.GetByName(request.Name);
                if(checkExist != null){
                     result.Success = false;
                     result.Errors.Add("Hotel already exist");
                     return result;
                }

                var dbResponse = await _repository.Add(
                new Hotel
                {
                    HotelId = Guid.NewGuid(),
                    Address = request.Address,
                    Price = request.Price,
                    Name = request.Name,
                    Description = request.Description,
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