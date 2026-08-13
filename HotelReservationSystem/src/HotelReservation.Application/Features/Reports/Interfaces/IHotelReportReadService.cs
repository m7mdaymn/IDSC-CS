using HotelReservation.Application.Features.Reports.Dtos;

namespace HotelReservation.Application.Features.Reports.Interfaces;

public interface IHotelReportReadService
{
    Task<HotelReportDto> GetAsync(
        CancellationToken cancellationToken = default);
}