using HotelReservation.Application.Common.Models.Pagination;
using HotelReservation.Application.Features.Rooms.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Rooms.Queries.GetAvailableRooms;

public sealed record GetAvailableRoomsQuery(
    int PageNumber = 1,
    int PageSize = 10)
    : IRequest<PagedResult<RoomDto>>;