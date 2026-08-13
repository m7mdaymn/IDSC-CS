namespace HotelReservation.Api.Contracts.Identity;

public sealed record CreateStaffUserRequest(
    string Email,
    string Password,
    string Role);