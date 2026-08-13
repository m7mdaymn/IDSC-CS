using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Features.Reservations.Dtos;
using HotelReservation.Application.Features.Reservations.Specifications;
using HotelReservation.Application.Features.Rooms.Specifications;
using HotelReservation.Domain.Entities;
using MediatR;

namespace HotelReservation.Application.Features.Reservations.Commands.ReserveRoom;

public sealed class ReserveRoomCommandHandler
    : IRequestHandler<ReserveRoomCommand, ReservationDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReserveRoomCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ReservationDto> Handle(
        ReserveRoomCommand request,
        CancellationToken cancellationToken)
    {
        var roomRepository =
            _unitOfWork.Repository<Room>();

        var reservationRepository =
            _unitOfWork.Repository<Reservation>();


        var room =
            await roomRepository.FirstOrDefaultAsync(
                new RoomByNumberForUpdateSpecification(
                    request.RoomNumber),
                cancellationToken);


        if (room is null)
        {
            throw new NotFoundException(
                $"Room number {request.RoomNumber} was not found.");
        }


        if (room.IsReserved)
        {
            throw new ConflictException(
                $"Room number {request.RoomNumber} is already reserved.");
        }


        var reservationNumber =
            await GenerateReservationNumberAsync(
                reservationRepository,
                cancellationToken);


        var reservation =
            Reservation.Create(
                reservationNumber,
                room.Id,
                request.CustomerName,
                request.CustomerPhone,
                request.NumberOfDays,
                room.PricePerDay,
                request.CheckInDate);


        room.Reserve();


        await reservationRepository.AddAsync(
            reservation,
            cancellationToken);


        await _unitOfWork.SaveChangesAsync(
            cancellationToken);


        return new ReservationDto(
            reservation.Id,
            reservation.ReservationNumber,
            room.RoomNumber,
            reservation.CustomerName,
            reservation.CustomerPhone,
            reservation.NumberOfDays,
            reservation.PricePerDay,
            reservation.SubTotal,
            reservation.DiscountPercentage,
            reservation.DiscountAmount,
            reservation.TotalCost,
            reservation.Status.ToString(),
            reservation.ReservationDateUtc,
            reservation.CheckInDate,
            reservation.CheckOutDate,
            reservation.CancelledAtUtc);
    }


    private static async Task<int>
        GenerateReservationNumberAsync(
            IGenericRepository<Reservation> repository,
            CancellationToken cancellationToken)
    {
        const int maxAttempts = 20;

        for (var attempt = 0;
             attempt < maxAttempts;
             attempt++)
        {
            var number =
                Random.Shared.Next(
                    10000,
                    100000);

            var exists =
                await repository.AnyAsync(
                    new ReservationByNumberSpecification(
                        number),
                    cancellationToken);

            if (!exists)
            {
                return number;
            }
        }

        throw new ConflictException(
            "Could not generate a unique reservation number.");
    }
}