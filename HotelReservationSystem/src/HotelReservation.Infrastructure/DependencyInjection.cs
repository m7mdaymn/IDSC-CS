using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Infrastructure.Persistence;
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

        return services;
    }
}