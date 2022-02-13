using FluentValidation;

namespace application.Features.Bookings.Commands
{
    public class AddBookingValidator: AbstractValidator<AddBookingRequest>
    {
        public AddBookingValidator()
        {
           
        }

    }
}