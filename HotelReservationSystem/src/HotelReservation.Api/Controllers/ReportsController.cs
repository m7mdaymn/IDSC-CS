using HotelReservation.Api.Responses.Common;
using HotelReservation.Application.Features.Reports.Dtos;
using HotelReservation.Application.Features.Reports.Queries.GetHotelReport;
using HotelReservation.Application.Common.Authorization;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.Controllers;

[ApiController]
[Route("api/reports")]
[Authorize(Policy = AppPolicies.ViewReports)]
public sealed class ReportsController : ControllerBase
{
    private readonly ISender _sender;

    public ReportsController(
        ISender sender)
    {
        _sender = sender;
    }


    [HttpGet("hotel")]
    public async Task<ActionResult<ApiResponse<HotelReportDto>>>
        GetHotelReport(
            CancellationToken cancellationToken)
    {
        var report =
            await _sender.Send(
                new GetHotelReportQuery(),
                cancellationToken);

        return Ok(
            new ApiResponse<HotelReportDto>(
                report,
                "Hotel report retrieved successfully.",
                HttpContext.TraceIdentifier));
    }
}