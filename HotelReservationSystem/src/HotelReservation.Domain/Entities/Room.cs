using HotelReservation.Domain.Common;
using HotelReservation.Domain.Exceptions;

namespace HotelReservation.Domain.Entities;

public sealed class Room : BaseEntity, ISoftDeletable
{
    private Room()
    {
        // EF Core
    }

    private Room(
        int roomNumber,
        decimal pricePerDay)
    {
        if (roomNumber <= 0)
        {
            throw new DomainException(
                "Room number must be greater than zero.");
        }

        if (pricePerDay <= 0)
        {
            throw new DomainException(
                "Price per day must be greater than zero.");
        }

        RoomNumber = roomNumber;
        PricePerDay = pricePerDay;
        IsReserved = false;
    }

    public int RoomNumber { get; private set; }

    public decimal PricePerDay { get; private set; }

    public bool IsReserved { get; private set; }


    public bool IsDeleted { get; private set; }

    public DateTime? DeletedAtUtc { get; private set; }


    public static Room Create(
        int roomNumber,
        decimal pricePerDay)
    {
        return new Room(
            roomNumber,
            pricePerDay);
    }


    public void Reserve()
    {
        if (IsDeleted)
        {
            throw new DomainException(
                "A deleted room cannot be reserved.");
        }

        if (IsReserved)
        {
            throw new DomainException(
                $"Room {RoomNumber} is already reserved.");
        }

        IsReserved = true;

        MarkAsUpdated();
    }


    public void Release()
    {
        if (!IsReserved)
        {
            throw new DomainException(
                $"Room {RoomNumber} is not currently reserved.");
        }

        IsReserved = false;

        MarkAsUpdated();
    }


    public void SoftDelete()
    {
        if (IsReserved)
        {
            throw new DomainException(
                "A reserved room cannot be deleted.");
        }

        if (IsDeleted)
        {
            return;
        }

        IsDeleted = true;
        DeletedAtUtc = DateTime.UtcNow;

        MarkAsUpdated();
    }
}