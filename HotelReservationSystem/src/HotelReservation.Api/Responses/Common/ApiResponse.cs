namespace HotelReservation.Api.Responses.Common;

public sealed record ApiResponse<T>(
    T Data,
    string Message,
    string TraceId);