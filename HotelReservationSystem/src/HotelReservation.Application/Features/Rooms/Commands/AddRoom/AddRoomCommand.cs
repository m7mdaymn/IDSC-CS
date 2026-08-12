using HotelReservation.Application.Features.Rooms.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Rooms.Commands.AddRoom;

public sealed record AddRoomCommand(
    int RoomNumber,
    decimal PricePerDay)
    : IRequest<RoomDto>;