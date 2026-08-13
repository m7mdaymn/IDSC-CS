using HotelReservation.Application.Common.Specifications;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Features.Rooms.Specifications;

public sealed class AvailableRoomsSpecification
    : BaseSpecification<Room>
{
    public AvailableRoomsSpecification(
        int pageNumber,
        int pageSize)
        : base(room =>
            !room.IsReserved)
    {
        ApplyOrderBy(room =>
            room.RoomNumber);

        ApplyPaging(
            (pageNumber - 1) * pageSize,
            pageSize);
    }
}