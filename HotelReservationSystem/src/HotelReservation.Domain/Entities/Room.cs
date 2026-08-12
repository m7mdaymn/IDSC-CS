using HotelReservation.Domain.Common;
using HotelReservation.Domain.Exceptions;

namespace HotelReservation.Domain.Entities;

public sealed class Room : BaseEntity
{
    private Room()
    {
        // Required by EF Core.
    }

    private Room(int roomNumber, decimal pricePerDay)
    {
        if (roomNumber <= 0)
            throw new DomainException(
                "Room number must be greater than zero.");

        if (pricePerDay <= 0)
            throw new DomainException(
                "Price per day must be greater than zero.");

        Id = Guid.NewGuid();

        RoomNumber = roomNumber;
        PricePerDay = pricePerDay;

        IsReserved = false;

        CustomerName = null;
        CustomerPhone = null;
        NumberOfDays = 0;
        ReservationDate = null;

        ReservationId = null;
        CheckInDate = null;
        CheckOutDate = null;
    }

    public int RoomNumber { get; private set; }

    public decimal PricePerDay { get; private set; }

    public bool IsReserved { get; private set; }

    public string? CustomerName { get; private set; }

    public string? CustomerPhone { get; private set; }

    public int NumberOfDays { get; private set; }

    public DateTime? ReservationDate { get; private set; }

    public int? ReservationId { get; private set; }

    public DateTime? CheckInDate { get; private set; }

    public DateTime? CheckOutDate { get; private set; }

    public static Room Create(
        int roomNumber,
        decimal pricePerDay)
    {
        return new Room(
            roomNumber,
            pricePerDay);
    }
}