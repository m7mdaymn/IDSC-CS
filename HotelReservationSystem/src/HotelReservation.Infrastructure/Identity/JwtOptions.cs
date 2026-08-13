namespace HotelReservation.Infrastructure.Identity;

public sealed class JwtOptions
{
    public const string SectionName =
        "Jwt";


    public string Issuer { get; init; }
        = null!;


    public string Audience { get; init; }
        = null!;


    public string Key { get; init; }
        = null!;


    public int ExpirationMinutes { get; init; }
        = 60;
}