using System.Security.Claims;
using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Identity;

namespace HotelReservation.Api.Services;

internal sealed class CurrentUserService
    : ICurrentUserService
{
    private readonly IHttpContextAccessor
        _httpContextAccessor;


    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor =
            httpContextAccessor;
    }


    private ClaimsPrincipal User =>
        _httpContextAccessor
            .HttpContext?
            .User
        ?? throw new UnauthorizedException(
            "No authenticated user is available.");


    public Guid UserId
    {
        get
        {
            var value =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);


            if (!Guid.TryParse(
                value,
                out var userId))
            {
                throw new UnauthorizedException(
                    "The authenticated user identifier is invalid.");
            }


            return userId;
        }
    }


    public string? Email =>
        User.FindFirstValue(
            ClaimTypes.Email);


    public IReadOnlyCollection<string> Roles =>
        User.FindAll(
                ClaimTypes.Role)
            .Select(claim =>
                claim.Value)
            .ToArray();
}