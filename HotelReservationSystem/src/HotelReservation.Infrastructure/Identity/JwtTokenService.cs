using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HotelReservation.Application.Common.Interfaces.Identity;
using HotelReservation.Application.Common.Models.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservation.Infrastructure.Identity;

internal sealed class JwtTokenService
    : ITokenService
{
    private readonly JwtOptions _options;

    public JwtTokenService(
        IOptions<JwtOptions> options)
    {
        _options =
            options.Value;
    }


    public AccessToken Generate(
        AuthenticatedUser user)
    {
        var expiresAtUtc =
            DateTime.UtcNow
                .AddMinutes(
                    _options.ExpirationMinutes);


        var claims =
            new List<Claim>
            {
                new(
                    JwtRegisteredClaimNames.Sub,
                    user.UserId.ToString()),

                new(
                    ClaimTypes.NameIdentifier,
                    user.UserId.ToString()),

                new(
                    ClaimTypes.Email,
                    user.Email),

                new(
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            };


        claims.AddRange(
            user.Roles.Select(
                role =>
                    new Claim(
                        ClaimTypes.Role,
                        role)));


        var signingKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _options.Key));


        var credentials =
            new SigningCredentials(
                signingKey,
                SecurityAlgorithms.HmacSha256);


        var token =
            new JwtSecurityToken(
                issuer:
                    _options.Issuer,

                audience:
                    _options.Audience,

                claims:
                    claims,

                expires:
                    expiresAtUtc,

                signingCredentials:
                    credentials);


        var tokenValue =
            new JwtSecurityTokenHandler()
                .WriteToken(
                    token);


        return new AccessToken(
            tokenValue,
            expiresAtUtc);
    }
}