using HotelReservation.Application.Common.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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


        var userManager =
            scope.ServiceProvider
                .GetRequiredService<
                    UserManager<ApplicationUser>>();


        var configuration =
            scope.ServiceProvider
                .GetRequiredService<IConfiguration>();


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
                await roleManager.RoleExistsAsync(
                    role);

            if (!exists)
            {
                var result =
                    await roleManager.CreateAsync(
                        new IdentityRole<Guid>
                        {
                            Id = Guid.NewGuid(),
                            Name = role
                        });

                EnsureSucceeded(
                    result,
                    $"Creating role '{role}'");
            }
        }


        var adminEmail =
            configuration["SeedAdmin:Email"];

        var adminPassword =
            configuration["SeedAdmin:Password"];


        if (string.IsNullOrWhiteSpace(adminEmail) ||
            string.IsNullOrWhiteSpace(adminPassword))
        {
            return;
        }


        var admin =
            await userManager.FindByEmailAsync(
                adminEmail);


        if (admin is null)
        {
            admin =
                new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };


            var createResult =
                await userManager.CreateAsync(
                    admin,
                    adminPassword);


            EnsureSucceeded(
                createResult,
                "Creating seeded admin");
        }


        var isAdmin =
            await userManager.IsInRoleAsync(
                admin,
                AppRoles.Admin);


        if (!isAdmin)
        {
            var roleResult =
                await userManager.AddToRoleAsync(
                    admin,
                    AppRoles.Admin);


            EnsureSucceeded(
                roleResult,
                "Assigning Admin role");
        }
    }


    private static void EnsureSucceeded(
        IdentityResult result,
        string operation)
    {
        if (result.Succeeded)
        {
            return;
        }


        var errors =
            string.Join(
                "; ",
                result.Errors.Select(
                    error =>
                        error.Description));


        throw new InvalidOperationException(
            $"{operation} failed: {errors}");
    }
}