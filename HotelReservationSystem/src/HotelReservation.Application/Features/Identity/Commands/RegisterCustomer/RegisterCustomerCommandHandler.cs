using HotelReservation.Application.Common.Authorization;
using HotelReservation.Application.Common.Interfaces.Identity;
using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Features.Identity.Dtos;
using HotelReservation.Domain.Entities;
using MediatR;

namespace HotelReservation.Application.Features.Identity.Commands.RegisterCustomer;

public sealed class RegisterCustomerCommandHandler
    : IRequestHandler<
        RegisterCustomerCommand,
        AuthDto>
{
    private readonly IIdentityService
        _identityService;

    private readonly ITokenService
        _tokenService;

    private readonly IUnitOfWork
        _unitOfWork;


    public RegisterCustomerCommandHandler(
        IIdentityService identityService,
        ITokenService tokenService,
        IUnitOfWork unitOfWork)
    {
        _identityService =
            identityService;

        _tokenService =
            tokenService;

        _unitOfWork =
            unitOfWork;
    }


    public async Task<AuthDto> Handle(
        RegisterCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            await _identityService.CreateUserAsync(
                request.Email,
                request.Password,
                AppRoles.Customer,
                cancellationToken);


        try
        {
            var customer =
                CustomerProfile.Create(
                    user.UserId,
                    request.FullName,
                    request.PhoneNumber);


            await _unitOfWork
                .Repository<CustomerProfile>()
                .AddAsync(
                    customer,
                    cancellationToken);


            await _unitOfWork.SaveChangesAsync(
                cancellationToken);
        }
        catch
        {
            await _identityService.DeleteUserAsync(
                user.UserId,
                cancellationToken);

            throw;
        }


        var accessToken =
            _tokenService.Generate(
                user);


        return new AuthDto(
            user.UserId,
            user.Email,
            user.Roles,
            accessToken.Token,
            accessToken.ExpiresAtUtc);
    }
}