using HotelReservation.Application.Common.Models.Identity;

namespace HotelReservation.Application.Common.Interfaces.Identity;

public interface ITokenService
{
    AccessToken Generate(
        AuthenticatedUser user);
}