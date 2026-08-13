using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Features.Reservations.Dtos;
using HotelReservation.Application.Features.Reservations.Specifications;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Enums;
using MediatR;

namespace HotelReservation.Application.Features.Reservations.Commands.CancelReservation;

public sealed class CancelReservationCommandHandler
    : IRequestHandler<
        CancelReservationCommand,
        ReservationDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CancelReservationCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<ReservationDto> Handle(
        CancelReservationCommand request,
        CancellationToken cancellationToken)
    {
        var repository =
            _unitOfWork.Repository<Reservation>();

        var reservation =
            await repository.FirstOrDefaultAsync(
                new ReservationByNumberForUpdateSpecification(
                    request.ReservationNumber),
                cancellationToken);


        if (reservation is null)
        {
            throw new NotFoundException(
                $"Reservation {request.ReservationNumber} was not found.");
        }


        if (reservation.Status ==
            ReservationStatus.Cancelled)
        {
            throw new ConflictException(
                "Reservation is already cancelled.");
        }


        var room =
            reservation.Room
            ?? throw new InvalidOperationException(
                "Reservation room relationship is invalid.");


        reservation.Cancel();

        room.Release();


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
}