using HotelReservation.Api.Contracts.Identity;
using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Features.Identity.Commands.Login;
using HotelReservation.Application.Features.Identity.Commands.RegisterCustomer;
using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Application.Common.Interfaces.Identity;

namespace HotelReservation.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController
    : ControllerBase
{
    private readonly ISender _sender;
    private readonly ICurrentUserService
    _currentUser;
    public AuthController(
        ISender sender,
        ICurrentUserService currentUser)
    {
        _sender =
            sender;

        _currentUser =
            currentUser;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<
        ActionResult<ApiResponse<AuthDto>>>
        Register(
            RegisterCustomerRequest request,
            CancellationToken cancellationToken)
    {
        var result =
            await _sender.Send(
                new RegisterCustomerCommand(
                    request.FullName,
                    request.PhoneNumber,
                    request.Email,
                    request.Password),
                cancellationToken);


        return StatusCode(
            StatusCodes.Status201Created,
            new ApiResponse<AuthDto>(
                result,
                "Customer account created successfully.",
                HttpContext.TraceIdentifier));
    }


    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<
        ActionResult<ApiResponse<AuthDto>>>
        Login(
            LoginRequest request,
            CancellationToken cancellationToken)
    {
        var result =
            await _sender.Send(
                new LoginCommand(
                    request.Email,
                    request.Password),
                cancellationToken);


        return Ok(
            new ApiResponse<AuthDto>(
                result,
                "Login successful.",
                HttpContext.TraceIdentifier));
    }

    [Authorize]
    [HttpGet("me")]
    public ActionResult<object> Me()
    {
        return Ok(
            new
            {
                userId =
                    _currentUser.UserId,

                email =
                    _currentUser.Email,

                roles =
                    _currentUser.Roles
            });
    }

}