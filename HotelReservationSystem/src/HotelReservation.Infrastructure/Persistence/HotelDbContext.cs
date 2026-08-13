using HotelReservation.Domain.Entities;
using HotelReservation.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Persistence;

public sealed class HotelDbContext
    : IdentityDbContext<
        ApplicationUser,
        IdentityRole<Guid>,
        Guid>
{
    public HotelDbContext(
        DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }


    public DbSet<Room> Rooms =>
        Set<Room>();

    public DbSet<Reservation> Reservations =>
        Set<Reservation>();

    public DbSet<CustomerProfile> CustomerProfiles =>
        Set<CustomerProfile>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(HotelDbContext).Assembly);
    }
}