using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Features.Reservations.Specifications;

public sealed class SearchReservationsSpecification
    : BaseSpecification<Reservation>
{
    public SearchReservationsSpecification(
        int? roomNumber,
        string? customerName,
        int pageNumber,
        int pageSize)
        : base(reservation =>
            (!roomNumber.HasValue ||
             reservation.Room!.RoomNumber ==
             roomNumber.Value)
            &&
            (string.IsNullOrWhiteSpace(customerName) ||
             reservation.CustomerName.Contains(
                 customerName)))
    {
        AddInclude(reservation =>
            reservation.Room!);

        ApplyOrderByDescending(
            reservation =>
                reservation.ReservationDateUtc);

        ApplyPaging(
            (pageNumber - 1) * pageSize,
            pageSize);
    }
}