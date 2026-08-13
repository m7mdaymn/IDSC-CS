using HotelReservation.Application.Common.Models.Identity;

namespace HotelReservation.Application.Common.Interfaces.Identity;

public interface IIdentityService
{
    Task<AuthenticatedUser> CreateUserAsync(
        string email,
        string password,
        string role,
        CancellationToken cancellationToken = default);

    Task<AuthenticatedUser?> ValidateCredentialsAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);

    Task DeleteUserAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}