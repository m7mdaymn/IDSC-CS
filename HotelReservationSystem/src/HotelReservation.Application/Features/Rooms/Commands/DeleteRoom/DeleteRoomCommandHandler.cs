using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Domain.Entities;
using MediatR;

namespace HotelReservation.Application.Features.Rooms.Commands.DeleteRoom;

public sealed class DeleteRoomCommandHandler
    : IRequestHandler<DeleteRoomCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoomCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<Guid> Handle(
        DeleteRoomCommand request,
        CancellationToken cancellationToken)
    {
        var repository =
            _unitOfWork.Repository<Room>();

        var room =
            await repository.GetByIdAsync(
                request.RoomId,
                cancellationToken);


        if (room is null)
        {
            throw new NotFoundException(
                "Room was not found.");
        }


        if (room.IsReserved)
        {
            throw new ConflictException(
                "A reserved room cannot be deleted.");
        }


        room.SoftDelete();


        await _unitOfWork.SaveChangesAsync(
            cancellationToken);


        return room.Id;
    }
}