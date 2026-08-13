using HotelReservation.Application.Features.Reservations.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Reservations.Commands.CancelReservation;

public sealed record CancelReservationCommand(
    int ReservationNumber)
    : IRequest<ReservationDto>;