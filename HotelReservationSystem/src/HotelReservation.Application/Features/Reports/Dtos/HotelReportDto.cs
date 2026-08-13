namespace HotelReservation.Application.Features.Reports.Dtos;

public sealed record HotelReportDto(
    int TotalRooms,
    int ReservedRooms,
    int AvailableRooms,
    decimal TotalRevenue);