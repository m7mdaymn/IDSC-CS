using FluentValidation;

namespace HotelReservation.Application.Features.Rooms.Commands.AddRoom;

public sealed class AddRoomCommandValidator
    : AbstractValidator<AddRoomCommand>
{
    public AddRoomCommandValidator()
    {
        RuleFor(command =>
                command.RoomNumber)
            .GreaterThan(0)
            .WithMessage(
                "Room number must be greater than zero.");

        RuleFor(command =>
                command.PricePerDay)
            .GreaterThan(0)
            .WithMessage(
                "Price per day must be greater than zero.");
    }
}