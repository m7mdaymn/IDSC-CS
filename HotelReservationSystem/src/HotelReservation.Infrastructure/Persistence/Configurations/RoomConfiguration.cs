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


        builder.HasKey(room =>
            room.Id);


        builder.Property(room =>
                room.RoomNumber)
            .IsRequired();


        builder.HasIndex(room =>
                room.RoomNumber)
            .IsUnique();


        builder.Property(room =>
                room.PricePerDay)
            .HasPrecision(18, 2)
            .IsRequired();


        builder.Property(room =>
                room.IsReserved)
            .IsRequired()
            .HasDefaultValue(false);


        builder.Property(room =>
                room.CreatedAtUtc)
            .IsRequired();


        builder.Property(room =>
            room.UpdatedAtUtc);


        builder.Property(room =>
                room.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);


        builder.Property(room =>
            room.DeletedAtUtc);
    }
}