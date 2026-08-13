using HotelReservation.Api.Contracts.Identity;
using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Features.Identity.Commands.Login;
using HotelReservation.Application.Features.Identity.Commands.RegisterCustomer;
using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController
    : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(
        ISender sender)
    {
        _sender =
            sender;
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
}