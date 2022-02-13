using System.Threading;
using System.Threading.Tasks;
using application.Repositories;

using MediatR;

namespace application.Features.Hotels.Commands
{
    public class DeleteHotelHandler : IRequestHandler<DeleteHotelRequest, DeleteHotelResponse>
    {
        private readonly IHotelRepository _repository;
        public DeleteHotelHandler(IHotelRepository repository)
        {
            _repository = repository;

        }
        public async Task<DeleteHotelResponse> Handle(DeleteHotelRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteHotelResponse{RequestId = request.RequestId};
            var validation = new DeleteHotelValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var dbResult = await _repository.Get(request.Id);
                if(dbResult == null){
                     result.Success = false;
                     result.Errors.Add("Type dosen't exist");
                     return result;
                }
                dbResult.Active = false;
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