using HotelReservation.Api.Contracts.Rooms;
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

    public RoomsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(RoomDto),
        StatusCodes.Status201Created)]
    [ProducesResponseType(
        typeof(ProblemDetails),
        StatusCodes.Status400BadRequest)]
    [ProducesResponseType(
        typeof(ProblemDetails),
        StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoomDto>> AddRoom(
        [FromBody] AddRoomRequest request,
        CancellationToken cancellationToken)
    {
        var command = new AddRoomCommand(
            request.RoomNumber,
            request.PricePerDay);

        var room = await _sender.Send(
            command,
            cancellationToken);

        return StatusCode(
            StatusCodes.Status201Created,
            room);
    }
}