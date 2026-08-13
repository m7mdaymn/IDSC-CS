namespace HotelReservation.Api.Contracts.Reservations;

public sealed record ReserveRoomRequest(
    int RoomNumber,
    string CustomerName,
    string CustomerPhone,
    int NumberOfDays,
    DateTime CheckInDate);