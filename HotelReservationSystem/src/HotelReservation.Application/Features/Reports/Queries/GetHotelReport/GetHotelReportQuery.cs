using HotelReservation.Application.Features.Reports.Dtos;
using MediatR;

namespace HotelReservation.Application.Features.Reports.Queries.GetHotelReport;

public sealed record GetHotelReportQuery
    : IRequest<HotelReportDto>;