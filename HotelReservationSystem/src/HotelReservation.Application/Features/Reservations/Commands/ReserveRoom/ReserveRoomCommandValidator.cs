using FluentValidation;

namespace HotelReservation.Application.Features.Reservations.Commands.ReserveRoom;

public sealed class ReserveRoomCommandValidator
    : AbstractValidator<ReserveRoomCommand>
{
    public ReserveRoomCommandValidator()
    {
        RuleFor(x => x.RoomNumber)
            .GreaterThan(0);

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.CustomerPhone)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.NumberOfDays)
            .GreaterThan(0);

        RuleFor(x => x.CheckInDate)
            .NotEmpty();
    }
}