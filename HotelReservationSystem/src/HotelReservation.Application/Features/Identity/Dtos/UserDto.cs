namespace HotelReservation.Application.Features.Identity.Dtos;

public sealed record UserDto(
    Guid UserId,
    string Email,
    IReadOnlyCollection<string> Roles);