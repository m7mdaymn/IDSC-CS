using HotelReservation.Api.Contracts.Identity;
using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Common.Authorization;
using HotelReservation.Application.Features.Identity.Commands.CreateStaffUser;
using HotelReservation.Application.Features.Identity.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers;


[ApiController]
[Route("api/users")]
[Authorize(Policy = AppPolicies.ManageUsers)]
public sealed class UsersController
    : ControllerBase
{
    private readonly ISender _sender;


    public UsersController(
        ISender sender)
    {
        _sender = sender;
    }


    [HttpPost("staff")]
    public async Task<
        ActionResult<ApiResponse<UserDto>>>
        CreateStaff(
            [FromBody]
            CreateStaffUserRequest request,

            CancellationToken cancellationToken)
    {
        var result =
            await _sender.Send(
                new CreateStaffUserCommand(
                    request.Email,
                    request.Password,
                    request.Role),
                cancellationToken);


        return StatusCode(
            StatusCodes.Status201Created,
            new ApiResponse<UserDto>(
                result,
                "Staff account created successfully.",
                HttpContext.TraceIdentifier));
    }
}