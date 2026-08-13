using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Identity.Commands.RegisterCustomer;

public sealed record RegisterCustomerCommand(
    string FullName,
    string PhoneNumber,
    string Email,
    string Password)
    : IRequest<AuthDto>;