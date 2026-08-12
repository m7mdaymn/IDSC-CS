using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Features.Rooms.Specifications;

public sealed class RoomByNumberSpecification
    : BaseSpecification<Room>
{
    public RoomByNumberSpecification(
        int roomNumber)
        : base(
            room =>
                room.RoomNumber == roomNumber)
    {
    }
}