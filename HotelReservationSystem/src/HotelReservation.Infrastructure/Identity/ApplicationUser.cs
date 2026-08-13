using Microsoft.AspNetCore.Identity;

namespace HotelReservation.Infrastructure.Identity;

public sealed class ApplicationUser
    : IdentityUser<Guid>
{
    public DateTime CreatedAtUtc { get; set; }
        = DateTime.UtcNow;

    public bool IsActive { get; set; }
        = true;
}