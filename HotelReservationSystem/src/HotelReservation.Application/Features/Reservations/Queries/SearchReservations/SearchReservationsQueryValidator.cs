using FluentValidation;

namespace HotelReservation.Application.Features.Reservations.Queries.SearchReservations;

public sealed class SearchReservationsQueryValidator
    : AbstractValidator<SearchReservationsQuery>
{
    public SearchReservationsQueryValidator()
    {
        RuleFor(x => x.RoomNumber)
            .GreaterThan(0)
            .When(x => x.RoomNumber.HasValue);

        RuleFor(x => x.CustomerName)
            .MaximumLength(150);

        RuleFor(x => x.PageNumber)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100);
    }
}