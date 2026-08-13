using HotelReservation.Application.Features.Reports.Dtos;
using HotelReservation.Application.Features.Reports.Interfaces;
using HotelReservation.Domain.Enums;
using HotelReservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Reporting;

internal sealed class HotelReportReadService
    : IHotelReportReadService
{
    private readonly HotelDbContext _context;

    public HotelReportReadService(
        HotelDbContext context)
    {
        _context = context;
    }

    public async Task<HotelReportDto> GetAsync(
        CancellationToken cancellationToken = default)
    {
        var roomsQuery =
            _context.Rooms
                .AsNoTracking()
                .Where(room =>
                    !room.IsDeleted);

        var totalRooms =
            await roomsQuery.CountAsync(
                cancellationToken);

        var reservedRooms =
            await roomsQuery.CountAsync(
                room => room.IsReserved,
                cancellationToken);

        var availableRooms =
            totalRooms - reservedRooms;

        var totalRevenue =
            await _context.Reservations
                .AsNoTracking()
                .Where(reservation =>
                    reservation.Status ==
                    ReservationStatus.Active)
                .SumAsync(
                    reservation =>
                        (decimal?)reservation.TotalCost,
                    cancellationToken)
            ?? 0m;

        return new HotelReportDto(
            totalRooms,
            reservedRooms,
            availableRooms,
            totalRevenue);
    }
}