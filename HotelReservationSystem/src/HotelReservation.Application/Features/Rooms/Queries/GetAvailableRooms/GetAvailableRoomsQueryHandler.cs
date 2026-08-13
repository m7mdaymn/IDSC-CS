using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Common.Models.Pagination;
using HotelReservation.Application.Features.Rooms.Dtos;
using HotelReservation.Application.Features.Rooms.Specifications;
using HotelReservation.Domain.Entities;
using MediatR;

namespace HotelReservation.Application.Features.Rooms.Queries.GetAvailableRooms;

public sealed class GetAvailableRoomsQueryHandler
    : IRequestHandler<
        GetAvailableRoomsQuery,
        PagedResult<RoomDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAvailableRoomsQueryHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResult<RoomDto>> Handle(
        GetAvailableRoomsQuery request,
        CancellationToken cancellationToken)
    {
        var repository =
            _unitOfWork.Repository<Room>();

        var specification =
            new AvailableRoomsSpecification(
                request.PageNumber,
                request.PageSize);

        var rooms =
            await repository.ListAsync(
                specification,
                cancellationToken);

        var totalCount =
            await repository.CountAsync(
                specification,
                cancellationToken);

        var roomDtos =
            rooms
                .Select(room =>
                    new RoomDto(
                        room.Id,
                        room.RoomNumber,
                        room.PricePerDay,
                        room.IsReserved))
                .ToList();

        return new PagedResult<RoomDto>(
            roomDtos,
            request.PageNumber,
            request.PageSize,
            totalCount);
    }
}