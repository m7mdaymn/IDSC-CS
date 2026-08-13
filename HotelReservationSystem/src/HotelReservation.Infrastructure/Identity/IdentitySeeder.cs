using HotelReservation.Application.Common.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservation.Infrastructure.Identity;

public static class IdentitySeeder
{
    public static async Task SeedIdentityAsync(
        this IServiceProvider services)
    {
        using var scope =
            services.CreateScope();


        var roleManager =
            scope.ServiceProvider
                .GetRequiredService<
                    RoleManager<IdentityRole<Guid>>>();


        string[] roles =
        [
            AppRoles.Admin,
            AppRoles.Manager,
            AppRoles.Receptionist,
            AppRoles.Customer
        ];


        foreach (var role in roles)
        {
            var exists =
                await roleManager
                    .RoleExistsAsync(
                        role);


            if (!exists)
            {
                await roleManager.CreateAsync(
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),

                        Name =
                            role
                    });
            }
        }
    }
}