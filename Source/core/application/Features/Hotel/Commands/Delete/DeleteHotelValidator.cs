using FluentValidation;

namespace application.Features.Hotels.Commands
{
    public class DeleteHotelValidator: AbstractValidator<DeleteHotelRequest>
    {
        public DeleteHotelValidator()
        {
           
        }

    }
}