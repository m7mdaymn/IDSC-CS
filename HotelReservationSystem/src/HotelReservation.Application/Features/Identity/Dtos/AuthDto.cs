namespace HotelReservation.Application.Features.Identity.Dtos;

public sealed record AuthDto(
    Guid UserId,
    string Email,
    IReadOnlyCollection<string> Roles,
    string AccessToken,
    DateTime ExpiresAtUtc);