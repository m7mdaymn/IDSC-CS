using MediatR;

namespace HotelReservation.Application.Features.Rooms.Commands.DeleteRoom;

public sealed record DeleteRoomCommand(
    Guid RoomId)
    : IRequest<Guid>;