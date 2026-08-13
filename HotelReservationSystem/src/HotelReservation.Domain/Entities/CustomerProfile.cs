using HotelReservation.Domain.Common;
using HotelReservation.Domain.Exceptions;

namespace HotelReservation.Domain.Entities;

public sealed class CustomerProfile : BaseEntity
{
    private CustomerProfile()
    {
        // EF Core
    }

    private CustomerProfile(
        Guid accountId,
        string fullName,
        string phoneNumber)
    {
        if (accountId == Guid.Empty)
        {
            throw new DomainException(
                "A valid account ID is required.");
        }

        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new DomainException(
                "Customer full name is required.");
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new DomainException(
                "Customer phone number is required.");
        }

        AccountId =
            accountId;

        FullName =
            fullName.Trim();

        PhoneNumber =
            phoneNumber.Trim();
    }


    public Guid AccountId { get; private set; }


    public string FullName { get; private set; }
        = null!;


    public string PhoneNumber { get; private set; }
        = null!;


    public static CustomerProfile Create(
        Guid accountId,
        string fullName,
        string phoneNumber)
    {
        return new CustomerProfile(
            accountId,
            fullName,
            phoneNumber);
    }
}