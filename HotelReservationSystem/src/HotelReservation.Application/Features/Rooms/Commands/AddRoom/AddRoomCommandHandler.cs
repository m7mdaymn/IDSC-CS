using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Features.Rooms.Dtos;
using HotelReservation.Application.Features.Rooms.Specifications;
using HotelReservation.Domain.Entities;
using MediatR;

namespace HotelReservation.Application.Features.Rooms.Commands.AddRoom;

public sealed class AddRoomCommandHandler
    : IRequestHandler<AddRoomCommand, RoomDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddRoomCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RoomDto> Handle(
        AddRoomCommand request,
        CancellationToken cancellationToken)
    {
        var repository =
            _unitOfWork.Repository<Room>();

        var specification =
            new RoomByNumberSpecification(
                request.RoomNumber);

        var roomExists =
            await repository.AnyAsync(
                specification,
                cancellationToken);

        if (roomExists)
        {
            throw new ConflictException(
                $"Room number {request.RoomNumber} already exists.");
        }

        var room = Room.Create(
            request.RoomNumber,
            request.PricePerDay);

        await repository.AddAsync(
            room,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return new RoomDto(
            room.Id,
            room.RoomNumber,
            room.PricePerDay,
            room.IsReserved);
    }
}