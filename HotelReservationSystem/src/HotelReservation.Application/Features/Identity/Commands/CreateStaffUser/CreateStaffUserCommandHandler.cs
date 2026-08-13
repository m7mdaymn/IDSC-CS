using HotelReservation.Application.Common.Interfaces.Identity;
using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Identity.Commands.CreateStaffUser;

public sealed class CreateStaffUserCommandHandler
    : IRequestHandler<
        CreateStaffUserCommand,
        UserDto>
{
    private readonly IIdentityService
        _identityService;


    public CreateStaffUserCommandHandler(
        IIdentityService identityService)
    {
        _identityService =
            identityService;
    }


    public async Task<UserDto> Handle(
        CreateStaffUserCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _identityService.CreateUserAsync(
                request.Email,
                request.Password,
                request.Role,
                cancellationToken);


        return new UserDto(
            user.UserId,
            user.Email,
            user.Roles);
    }
}