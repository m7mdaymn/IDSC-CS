namespace HotelReservation.Application.Features.Rooms.Dtos;

public sealed record RoomDto(
    Guid Id,
    int RoomNumber,
    decimal PricePerDay,
    bool IsReserved);