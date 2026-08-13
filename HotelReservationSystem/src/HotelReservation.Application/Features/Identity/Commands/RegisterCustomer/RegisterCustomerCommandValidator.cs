using FluentValidation;

namespace HotelReservation.Application.Features.Identity.Commands.RegisterCustomer;

public sealed class RegisterCustomerCommandValidator
    : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(150);


        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(30);


        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();


        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}