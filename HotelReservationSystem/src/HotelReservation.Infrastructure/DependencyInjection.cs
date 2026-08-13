using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Features.Reports.Interfaces;
using HotelReservation.Infrastructure.Persistence;
using HotelReservation.Infrastructure.Reporting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<HotelDbContext>(
            options =>
                options.UseSqlServer(
                    connectionString));

        services.AddScoped<
            IUnitOfWork,
            UnitOfWork>();

        services.AddScoped<
            IHotelReportReadService,
            HotelReportReadService>();

        return services;
    }
}