using HotelReservation.Application.Common.Models.Pagination;
using HotelReservation.Application.Features.Reservations.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Reservations.Queries.SearchReservations;

public sealed record SearchReservationsQuery(
    int? RoomNumber,
    string? CustomerName,
    int PageNumber = 1,
    int PageSize = 10)
    : IRequest<PagedResult<ReservationDto>>;