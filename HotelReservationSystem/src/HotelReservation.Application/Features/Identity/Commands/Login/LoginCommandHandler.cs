using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Application.Common.Interfaces.Identity;
using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Identity.Commands.Login;

public sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, AuthDto>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(
        IIdentityService identityService,
        ITokenService tokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
    }

    public async Task<AuthDto> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _identityService.ValidateCredentialsAsync(
                request.Email,
                request.Password,
                cancellationToken);

        if (user is null)
        {
            throw new UnauthorizedException(
                "Invalid email or password.");
        }

        var accessToken =
            _tokenService.Generate(user);

        return new AuthDto(
            user.UserId,
            user.Email,
            user.Roles,
            accessToken.Token,
            accessToken.ExpiresAtUtc);
    }
}