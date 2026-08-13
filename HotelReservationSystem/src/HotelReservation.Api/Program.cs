using System.Security.Claims;
using System.Text;
using HotelReservation.Application.Common.Authorization;
using HotelReservation.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HotelReservation.Api.ExceptionHandling;
using HotelReservation.Application;
using HotelReservation.Infrastructure;
using HotelReservation.Infrastructure.Identity;

var builder =
    WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<
    GlobalExceptionHandler>();

builder.Services.AddApplication();
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(
        JwtOptions.SectionName));

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var jwtOptions =
    builder.Configuration
        .GetSection(
            JwtOptions.SectionName)
        .Get<JwtOptions>()
    ?? throw new InvalidOperationException(
        "JWT configuration is missing.");


builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer =
                        true,

                    ValidateAudience =
                        true,

                    ValidateLifetime =
                        true,

                    ValidateIssuerSigningKey =
                        true,

                    ValidIssuer =
                        jwtOptions.Issuer,

                    ValidAudience =
                        jwtOptions.Audience,

                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                jwtOptions.Key)),

                    NameClaimType =
                        ClaimTypes.NameIdentifier,

                    RoleClaimType =
                        ClaimTypes.Role,

                    ClockSkew =
                        TimeSpan.FromMinutes(1)
                };
        });
var connectionString =
    builder.Configuration
        .GetConnectionString(
            "DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' was not found.");

builder.Services.AddInfrastructure(
    connectionString);

builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy(
            AppPolicies.ManageUsers,
            policy =>
                policy.RequireRole(
                    AppRoles.Admin));


        options.AddPolicy(
            AppPolicies.ManageRooms,
            policy =>
                policy.RequireRole(
                    AppRoles.Admin,
                    AppRoles.Manager));


        options.AddPolicy(
            AppPolicies.ManageReservations,
            policy =>
                policy.RequireRole(
                    AppRoles.Admin,
                    AppRoles.Manager,
                    AppRoles.Receptionist));


        options.AddPolicy(
            AppPolicies.ViewReports,
            policy =>
                policy.RequireRole(
                    AppRoles.Admin,
                    AppRoles.Manager));


        options.AddPolicy(
            AppPolicies.CustomerSelfService,
            policy =>
                policy.RequireRole(
                    AppRoles.Customer));
    });

var app =
    builder.Build();


    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Hotel Reservation API v1");
    });


await app.Services.SeedIdentityAsync();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program;