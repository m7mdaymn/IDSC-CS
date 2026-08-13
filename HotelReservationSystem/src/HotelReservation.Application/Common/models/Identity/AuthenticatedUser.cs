namespace HotelReservation.Application.Common.Models.Identity;

public sealed record AuthenticatedUser(
    Guid UserId,
    string Email,
    IReadOnlyCollection<string> Roles);