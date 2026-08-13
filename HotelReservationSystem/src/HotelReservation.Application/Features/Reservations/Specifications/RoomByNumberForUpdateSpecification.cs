using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Features.Rooms.Specifications;

public sealed class RoomByNumberForUpdateSpecification
    : BaseSpecification<Room>
{
    public RoomByNumberForUpdateSpecification(
        int roomNumber)
        : base(room =>
            room.RoomNumber == roomNumber)
    {
        EnableTracking();
    }
}