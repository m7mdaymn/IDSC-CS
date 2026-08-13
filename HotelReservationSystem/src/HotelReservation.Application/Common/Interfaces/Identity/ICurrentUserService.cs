namespace HotelReservation.Application.Common.Interfaces.Identity;

public interface ICurrentUserService
{
    Guid UserId { get; }

    string? Email { get; }

    IReadOnlyCollection<string> Roles { get; }
}