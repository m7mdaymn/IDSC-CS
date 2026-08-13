using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Identity.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password)
    : IRequest<AuthDto>;