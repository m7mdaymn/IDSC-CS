namespace HotelReservation.Api.Contracts.Identity;

public sealed record RegisterCustomerRequest(
    string FullName,
    string PhoneNumber,
    string Email,
    string Password);