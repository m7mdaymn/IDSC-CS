using HotelReservation.Api.Contracts.Rooms;
using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Features.Rooms.Commands.AddRoom;
using HotelReservation.Application.Features.Rooms.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers;


[ApiController]
[Route("api/rooms")]
public sealed class RoomsController : ControllerBase
{
    private readonly ISender _sender;


    public RoomsController(
        ISender sender)
    {
        _sender = sender;
    }


    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(
        typeof(ApiResponse<RoomDto>),
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ProblemDetails),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(ProblemDetails),
        StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ApiResponse<RoomDto>>> AddRoom(
        [FromBody] AddRoomRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new AddRoomCommand(
                request.RoomNumber,
                request.PricePerDay);


        var room =
            await _sender.Send(
                command,
                cancellationToken);


        var response =
            new ApiResponse<RoomDto>(
                room,
                "Room added successfully.",
                HttpContext.TraceIdentifier);


        return StatusCode(
            StatusCodes.Status201Created,
            response);
    }
}