namespace HotelReservation.Api.Contracts.Rooms;

public sealed record AddRoomRequest(
    int RoomNumber,
    decimal PricePerDay);