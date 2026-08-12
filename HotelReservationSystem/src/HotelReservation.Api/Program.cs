using HotelReservation.Api.ExceptionHandling;
using HotelReservation.Application;
using HotelReservation.Infrastructure;

var builder =
    WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<
    GlobalExceptionHandler>();

builder.Services.AddApplication();

var connectionString =
    builder.Configuration
        .GetConnectionString(
            "DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' was not found.");

builder.Services.AddInfrastructure(
    connectionString);

var app =
    builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Hotel Reservation API v1");
    });
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program;