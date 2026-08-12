using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Infrastructure.Persistence.Configurations;

public sealed class RoomConfiguration
    : IEntityTypeConfiguration<Room>
{
    public void Configure(
        EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(room => room.Id);

        builder.Property(room => room.RoomNumber)
            .IsRequired();

        builder.HasIndex(room => room.RoomNumber)
            .IsUnique();

        builder.Property(room => room.PricePerDay)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(room => room.IsReserved)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(room => room.CustomerName)
            .HasMaxLength(150);

        builder.Property(room => room.CustomerPhone)
            .HasMaxLength(30);

        builder.Property(room => room.NumberOfDays)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(room => room.ReservationId);

        builder.Property(room => room.ReservationDate);

        builder.Property(room => room.CheckInDate);

        builder.Property(room => room.CheckOutDate);
    }
}