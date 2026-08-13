using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Features.Reports.Interfaces;
using HotelReservation.Application.Common.Interfaces.Identity;
using HotelReservation.Infrastructure.Persistence;
using HotelReservation.Infrastructure.Reporting;
using HotelReservation.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
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

            services
        .AddIdentityCore<ApplicationUser>(
            options =>
            {
                options.Password.RequiredLength =
                    8;

                options.Password.RequireDigit =
                    true;

                options.Password.RequireUppercase =
                    true;

                options.Password.RequireLowercase =
                    true;

                options.Password.RequireNonAlphanumeric =
                    false;

                options.User.RequireUniqueEmail =
                    true;
            })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<HotelDbContext>()
        .AddDefaultTokenProviders();
        
        services.AddScoped<
            IUnitOfWork,
            UnitOfWork>();

        services.AddScoped<
            IHotelReportReadService,
            HotelReportReadService>();
        
        services.AddScoped<
            IIdentityService,
            IdentityService>();

        services.AddScoped<
            ITokenService,
            JwtTokenService>();

        return services;
    }
}