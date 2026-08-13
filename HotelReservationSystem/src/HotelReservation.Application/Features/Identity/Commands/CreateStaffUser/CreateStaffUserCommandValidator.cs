using FluentValidation;
using HotelReservation.Application.Common.Authorization;

namespace HotelReservation.Application.Features.Identity.Commands.CreateStaffUser;

public sealed class CreateStaffUserCommandValidator
    : AbstractValidator<CreateStaffUserCommand>
{
    public CreateStaffUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();


        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);


        RuleFor(x => x.Role)
            .Must(role =>
                role == AppRoles.Manager ||
                role == AppRoles.Receptionist)
            .WithMessage(
                $"Role must be either " +
                $"{AppRoles.Manager} or " +
                $"{AppRoles.Receptionist}.");
    }
}