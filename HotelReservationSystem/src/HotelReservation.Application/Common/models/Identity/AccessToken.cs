namespace HotelReservation.Application.Common.Models.Identity;

public sealed record AccessToken(
    string Token,
    DateTime ExpiresAtUtc);