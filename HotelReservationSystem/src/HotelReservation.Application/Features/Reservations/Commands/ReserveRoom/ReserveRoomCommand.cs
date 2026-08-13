using HotelReservation.Application.Features.Reservations.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Reservations.Commands.ReserveRoom;

public sealed record ReserveRoomCommand(
    int RoomNumber,
    string CustomerName,
    string CustomerPhone,
    int NumberOfDays,
    DateTime CheckInDate)
    : IRequest<ReservationDto>;