using FluentValidation;

namespace HotelReservation.Application.Features.Rooms.Queries.GetAvailableRooms;

public sealed class GetAvailableRoomsQueryValidator
    : AbstractValidator<GetAvailableRoomsQuery>
{
    public GetAvailableRoomsQueryValidator()
    {
        RuleFor(query =>
                query.PageNumber)
            .GreaterThan(0);

        RuleFor(query =>
                query.PageSize)
            .InclusiveBetween(1, 100);
    }
}