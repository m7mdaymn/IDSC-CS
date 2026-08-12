using HotelReservation.Domain.Common;
using HotelReservation.Domain.Exceptions;
using HotelReservation.Domain.Enums;

namespace HotelReservation.Domain.Entities;

public sealed class Reservation : BaseEntity
{
    private Reservation()
    {
        // EF Core
    }

    private Reservation(
        int reservationNumber,
        Guid roomId,
        string customerName,
        string customerPhone,
        int numberOfDays,
        decimal pricePerDay,
        DateTime checkInDate)
    {
        if (reservationNumber < 10000 ||
            reservationNumber > 99999)
        {
            throw new DomainException(
                "Reservation number must be a 5-digit number.");
        }

        if (roomId == Guid.Empty)
        {
            throw new DomainException(
                "A valid room is required.");
        }

        if (string.IsNullOrWhiteSpace(customerName))
        {
            throw new DomainException(
                "Customer name is required.");
        }

        if (string.IsNullOrWhiteSpace(customerPhone))
        {
            throw new DomainException(
                "Customer phone is required.");
        }

        if (numberOfDays <= 0)
        {
            throw new DomainException(
                "Number of days must be greater than zero.");
        }

        if (pricePerDay <= 0)
        {
            throw new DomainException(
                "Price per day must be greater than zero.");
        }

        ReservationNumber = reservationNumber;
        RoomId = roomId;

        CustomerName = customerName.Trim();
        CustomerPhone = customerPhone.Trim();

        NumberOfDays = numberOfDays;

        PricePerDay = pricePerDay;

        SubTotal =
            NumberOfDays * PricePerDay;

        DiscountPercentage =
            NumberOfDays > 7
                ? 10m
                : 0m;

        DiscountAmount =
            SubTotal *
            (DiscountPercentage / 100m);

        TotalCost =
            SubTotal - DiscountAmount;

        ReservationDateUtc =
            DateTime.UtcNow;

        CheckInDate =
            checkInDate.Date;

        CheckOutDate =
            checkInDate.Date
                .AddDays(numberOfDays);

        Status =
            ReservationStatus.Active;
    }


    public int ReservationNumber { get; private set; }


    public Guid RoomId { get; private set; }

    public Room? Room { get; private set; }


    public string CustomerName { get; private set; } = null!;

    public string CustomerPhone { get; private set; } = null!;


    public int NumberOfDays { get; private set; }

    public decimal PricePerDay { get; private set; }


    public decimal SubTotal { get; private set; }

    public decimal DiscountPercentage { get; private set; }

    public decimal DiscountAmount { get; private set; }

    public decimal TotalCost { get; private set; }


    public DateTime ReservationDateUtc { get; private set; }

    public DateTime CheckInDate { get; private set; }

    public DateTime CheckOutDate { get; private set; }


    public ReservationStatus Status { get; private set; }

    public DateTime? CancelledAtUtc { get; private set; }


    public static Reservation Create(
        int reservationNumber,
        Guid roomId,
        string customerName,
        string customerPhone,
        int numberOfDays,
        decimal pricePerDay,
        DateTime checkInDate)
    {
        return new Reservation(
            reservationNumber,
            roomId,
            customerName,
            customerPhone,
            numberOfDays,
            pricePerDay,
            checkInDate);
    }


    public void Cancel()
    {
        if (Status == ReservationStatus.Cancelled)
        {
            throw new DomainException(
                "Reservation is already cancelled.");
        }

        Status =
            ReservationStatus.Cancelled;

        CancelledAtUtc =
            DateTime.UtcNow;

        MarkAsUpdated();
    }
}