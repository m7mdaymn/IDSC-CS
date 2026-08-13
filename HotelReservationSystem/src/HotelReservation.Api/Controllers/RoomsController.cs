using HotelReservation.Api.Contracts.Rooms;
using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Features.Rooms.Commands.AddRoom;
using HotelReservation.Application.Features.Rooms.Commands.DeleteRoom;
using HotelReservation.Application.Features.Rooms.Queries.GetAvailableRooms;
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


    [HttpGet("available")]
    [ProducesResponseType(
        typeof(PagedApiResponse<RoomDto>),
        StatusCodes.Status200OK)]
public async Task<ActionResult<PagedApiResponse<RoomDto>>>
    GetAvailableRooms(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
{
    var query =
        new GetAvailableRoomsQuery(
            pageNumber,
            pageSize);

    var result =
        await _sender.Send(
            query,
            cancellationToken);

    var response =
        new PagedApiResponse<RoomDto>(
            result.Items,
            new PaginationMetadata(
                result.PageNumber,
                result.PageSize,
                result.TotalCount,
                result.TotalPages,
                result.HasPreviousPage,
                result.HasNextPage),
            "Available rooms retrieved successfully.",
            HttpContext.TraceIdentifier);

    return Ok(response);
}
[HttpDelete("{roomId:guid}")]
[ProducesResponseType(
    StatusCodes.Status204NoContent)]
public async Task<IActionResult> DeleteRoom(
    Guid roomId,
    CancellationToken cancellationToken)
{
    await _sender.Send(
        new DeleteRoomCommand(roomId),
        cancellationToken);

    return NoContent();
}
}