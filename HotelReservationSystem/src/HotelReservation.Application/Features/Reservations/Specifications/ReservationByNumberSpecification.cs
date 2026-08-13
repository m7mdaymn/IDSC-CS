using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Features.Reservations.Specifications;

public sealed class ReservationByNumberSpecification
    : BaseSpecification<Reservation>
{
    public ReservationByNumberSpecification(
        int reservationNumber)
        : base(reservation =>
            reservation.ReservationNumber ==
            reservationNumber)
    {
    }
}