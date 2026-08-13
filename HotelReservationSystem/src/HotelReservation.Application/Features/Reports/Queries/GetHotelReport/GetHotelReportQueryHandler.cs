using HotelReservation.Application.Features.Reports.Dtos;
using HotelReservation.Application.Features.Reports.Interfaces;
using MediatR;

namespace HotelReservation.Application.Features.Reports.Queries.GetHotelReport;

public sealed class GetHotelReportQueryHandler
    : IRequestHandler<
        GetHotelReportQuery,
        HotelReportDto>
{
    private readonly IHotelReportReadService
        _reportService;

    public GetHotelReportQueryHandler(
        IHotelReportReadService reportService)
    {
        _reportService = reportService;
    }


    public Task<HotelReportDto> Handle(
        GetHotelReportQuery request,
        CancellationToken cancellationToken)
    {
        return _reportService.GetAsync(
            cancellationToken);
    }
}