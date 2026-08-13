using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Identity.Commands.CreateStaffUser;

public sealed record CreateStaffUserCommand(
    string Email,
    string Password,
    string Role)
    : IRequest<UserDto>;