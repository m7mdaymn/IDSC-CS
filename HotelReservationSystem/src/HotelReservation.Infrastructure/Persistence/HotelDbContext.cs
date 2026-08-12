using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Infrastructure.Persistence;

public sealed class HotelDbContext : DbContext
{
    public HotelDbContext(
        DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public DbSet<Room> Rooms =>
        Set<Room>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(HotelDbContext).Assembly);
    }
}