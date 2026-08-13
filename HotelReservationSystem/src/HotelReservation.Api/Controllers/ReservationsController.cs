using HotelReservation.Api.Contracts.Reservations;
using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Features.Reservations.Commands.ReserveRoom;
using HotelReservation.Application.Features.Reservations.Dtos;
using HotelReservation.Application.Features.Reservations.Queries.SearchReservations;
using HotelReservation.Application.Features.Reservations.Commands.CancelReservation;
using HotelReservation.Application.Common.Authorization;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers;

[ApiController]
[Route("api/reservations")]
[Authorize(Policy = AppPolicies.ManageReservations)]
public sealed class ReservationsController : ControllerBase
{
    private readonly ISender _sender;

    public ReservationsController(
        ISender sender)
    {
        _sender = sender;
    }


    [HttpPost]
    public async Task<ActionResult<ApiResponse<ReservationDto>>>
        ReserveRoom(
            [FromBody] ReserveRoomRequest request,
            CancellationToken cancellationToken)
    {
        var result =
            await _sender.Send(
                new ReserveRoomCommand(
                    request.RoomNumber,
                    request.CustomerName,
                    request.CustomerPhone,
                    request.NumberOfDays,
                    request.CheckInDate),
                cancellationToken);

        return StatusCode(
            StatusCodes.Status201Created,
            new ApiResponse<ReservationDto>(
                result,
                "Room reserved successfully.",
                HttpContext.TraceIdentifier));
    }

    [HttpGet]
public async Task<ActionResult<PagedApiResponse<ReservationDto>>>
    SearchReservations(
        [FromQuery] int? roomNumber,
        [FromQuery] string? customerName,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
{
    var result =
        await _sender.Send(
            new SearchReservationsQuery(
                roomNumber,
                customerName,
                pageNumber,
                pageSize),
            cancellationToken);

    return Ok(
        new PagedApiResponse<ReservationDto>(
            result.Items,
            new PaginationMetadata(
                result.PageNumber,
                result.PageSize,
                result.TotalCount,
                result.TotalPages,
                result.HasPreviousPage,
                result.HasNextPage),
            "Reservations retrieved successfully.",
            HttpContext.TraceIdentifier));
}
[HttpPost("{reservationNumber:int}/cancel")]
public async Task<ActionResult<ApiResponse<ReservationDto>>>
    CancelReservation(
        int reservationNumber,
        CancellationToken cancellationToken)
{
    var result =
        await _sender.Send(
            new CancelReservationCommand(
                reservationNumber),
            cancellationToken);

    return Ok(
        new ApiResponse<ReservationDto>(
            result,
            "Reservation cancelled successfully.",
            HttpContext.TraceIdentifier));
}
}