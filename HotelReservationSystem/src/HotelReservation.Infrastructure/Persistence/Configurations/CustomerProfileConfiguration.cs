using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Infrastructure.Persistence.Configurations;

public sealed class CustomerProfileConfiguration
    : IEntityTypeConfiguration<CustomerProfile>
{
    public void Configure(
        EntityTypeBuilder<CustomerProfile> builder)
    {
        builder.ToTable(
            "CustomerProfiles");


        builder.HasKey(customer =>
            customer.Id);


        builder.Property(customer =>
                customer.AccountId)
            .IsRequired();


        builder.HasIndex(customer =>
                customer.AccountId)
            .IsUnique();


        builder.Property(customer =>
                customer.FullName)
            .HasMaxLength(150)
            .IsRequired();


        builder.Property(customer =>
                customer.PhoneNumber)
            .HasMaxLength(30)
            .IsRequired();
    }
}