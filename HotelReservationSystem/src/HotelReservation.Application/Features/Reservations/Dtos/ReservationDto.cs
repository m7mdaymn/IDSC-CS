namespace HotelReservation.Application.Features.Reservations.Dtos;

public sealed record ReservationDto(
    Guid Id,
    int ReservationNumber,
    int RoomNumber,
    string CustomerName,
    string CustomerPhone,
    int NumberOfDays,
    decimal PricePerDay,
    decimal SubTotal,
    decimal DiscountPercentage,
    decimal DiscountAmount,
    decimal TotalCost,
    string Status,
    DateTime ReservationDateUtc,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    DateTime? CancelledAtUtc);