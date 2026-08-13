using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Features.Reservations.Specifications;

public sealed class ReservationByNumberForUpdateSpecification
    : BaseSpecification<Reservation>
{
    public ReservationByNumberForUpdateSpecification(
        int reservationNumber)
        : base(reservation =>
            reservation.ReservationNumber ==
            reservationNumber)
    {
        AddInclude(reservation =>
            reservation.Room!);

        EnableTracking();
    }
}