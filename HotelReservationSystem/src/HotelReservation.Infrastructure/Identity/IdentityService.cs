using FluentValidation;
using FluentValidation.Results;
using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Identity;
using HotelReservation.Application.Common.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace HotelReservation.Infrastructure.Identity;

internal sealed class IdentityService
    : IIdentityService
{
    private readonly UserManager<ApplicationUser>
        _userManager;

    public IdentityService(
        UserManager<ApplicationUser> userManager)
    {
        _userManager =
            userManager;
    }


    public async Task<AuthenticatedUser> CreateUserAsync(
        string email,
        string password,
        string role,
        CancellationToken cancellationToken = default)
    {
        cancellationToken
            .ThrowIfCancellationRequested();


        var normalizedEmail =
            email.Trim();


        var existingUser =
            await _userManager.FindByEmailAsync(
                normalizedEmail);


        if (existingUser is not null)
        {
            throw new ConflictException(
                "An account with this email already exists.");
        }


        var user =
            new ApplicationUser
            {
                Id = Guid.NewGuid(),

                UserName =
                    normalizedEmail,

                Email =
                    normalizedEmail
            };


        var createResult =
            await _userManager.CreateAsync(
                user,
                password);


        EnsureSucceeded(
            createResult);


        var roleResult =
            await _userManager.AddToRoleAsync(
                user,
                role);


        if (!roleResult.Succeeded)
        {
            await _userManager.DeleteAsync(
                user);

            EnsureSucceeded(
                roleResult);
        }


        return new AuthenticatedUser(
            user.Id,
            user.Email!,
            new[] { role });
    }


    public async Task<AuthenticatedUser?>
        ValidateCredentialsAsync(
            string email,
            string password,
            CancellationToken cancellationToken = default)
    {
        cancellationToken
            .ThrowIfCancellationRequested();


        var user =
            await _userManager.FindByEmailAsync(
                email.Trim());


        if (user is null ||
            !user.IsActive)
        {
            return null;
        }


        var passwordIsValid =
            await _userManager.CheckPasswordAsync(
                user,
                password);


        if (!passwordIsValid)
        {
            return null;
        }


        var roles =
            await _userManager.GetRolesAsync(
                user);


        return new AuthenticatedUser(
            user.Id,
            user.Email!,
            roles.ToArray());
    }


    public async Task DeleteUserAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken
            .ThrowIfCancellationRequested();


        var user =
            await _userManager.FindByIdAsync(
                userId.ToString());


        if (user is not null)
        {
            await _userManager.DeleteAsync(
                user);
        }
    }


    private static void EnsureSucceeded(
        IdentityResult result)
    {
        if (result.Succeeded)
        {
            return;
        }


        var failures =
            result.Errors
                .Select(error =>
                    new ValidationFailure(
                        "Identity",
                        error.Description))
                .ToArray();


        throw new ValidationException(
            failures);
    }
}