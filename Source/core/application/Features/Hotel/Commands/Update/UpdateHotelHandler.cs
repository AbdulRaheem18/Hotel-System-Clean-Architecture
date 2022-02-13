using System.Threading;
using System.Threading.Tasks;
using application.Repositories;
using MediatR;

namespace application.Features.Hotels.Commands
{
    public class UpdateHotelHandler : IRequestHandler<UpdateHotelRequest, UpdateHotelResponse>
    {
        private readonly IHotelRepository _repository;
        public UpdateHotelHandler(IHotelRepository repository)
        {
            _repository = repository;

        }
        public async Task<UpdateHotelResponse> Handle(UpdateHotelRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateHotelResponse{RequestId = request.RequestId};
            var validation = new UpdateHotelValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var dbResult = await _repository.Get(request.Id);
                if(dbResult == null){
                     result.Success = false;
                     result.Errors.Add("Period Type dosen't exist");
                     return result;
                }
                dbResult.Name = request.Name;
                dbResult.Description = request.Description;
                dbResult.ModifiedDate = System.DateTime.Now;                
                await _repository.Update(dbResult);
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