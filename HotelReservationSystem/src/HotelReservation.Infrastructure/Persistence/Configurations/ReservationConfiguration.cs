using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Infrastructure.Persistence.Configurations;

public sealed class ReservationConfiguration
    : IEntityTypeConfiguration<Reservation>
{
    public void Configure(
        EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");


        builder.HasKey(reservation =>
            reservation.Id);


        builder.Property(reservation =>
                reservation.ReservationNumber)
            .IsRequired();


        builder.HasIndex(reservation =>
                reservation.ReservationNumber)
            .IsUnique();


        builder.Property(reservation =>
                reservation.CustomerName)
            .HasMaxLength(150)
            .IsRequired();


        builder.Property(reservation =>
                reservation.CustomerPhone)
            .HasMaxLength(30)
            .IsRequired();


        builder.Property(reservation =>
                reservation.PricePerDay)
            .HasPrecision(18, 2);


        builder.Property(reservation =>
                reservation.SubTotal)
            .HasPrecision(18, 2);


        builder.Property(reservation =>
                reservation.DiscountPercentage)
            .HasPrecision(5, 2);


        builder.Property(reservation =>
                reservation.DiscountAmount)
            .HasPrecision(18, 2);


        builder.Property(reservation =>
                reservation.TotalCost)
            .HasPrecision(18, 2);


        builder.Property(reservation =>
                reservation.Status)
            .HasConversion<string>()
            .HasMaxLength(30);


        builder.HasOne(reservation =>
                reservation.Room)
            .WithMany()
            .HasForeignKey(reservation =>
                reservation.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}