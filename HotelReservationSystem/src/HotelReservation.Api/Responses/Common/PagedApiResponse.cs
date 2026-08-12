namespace HotelReservation.Api.Responses.Common;

public sealed record PagedApiResponse<T>(
    IReadOnlyList<T> Data,
    PaginationMetadata Pagination,
    string Message,
    string TraceId);