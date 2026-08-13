using HotelReservation.Application.Common.Interfaces.Persistence;
using HotelReservation.Application.Common.Models.Pagination;
using HotelReservation.Application.Features.Reservations.Dtos;
using HotelReservation.Application.Features.Reservations.Specifications;
using HotelReservation.Domain.Entities;
using MediatR;

namespace HotelReservation.Application.Features.Reservations.Queries.SearchReservations;

public sealed class SearchReservationsQueryHandler
    : IRequestHandler<
        SearchReservationsQuery,
        PagedResult<ReservationDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchReservationsQueryHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<PagedResult<ReservationDto>> Handle(
        SearchReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var repository =
            _unitOfWork.Repository<Reservation>();

        var specification =
            new SearchReservationsSpecification(
                request.RoomNumber,
                request.CustomerName,
                request.PageNumber,
                request.PageSize);

        var reservations =
            await repository.ListAsync(
                specification,
                cancellationToken);

        var totalCount =
            await repository.CountAsync(
                specification,
                cancellationToken);

        var items =
            reservations
                .Select(reservation =>
                    new ReservationDto(
                        reservation.Id,
                        reservation.ReservationNumber,
                        reservation.Room!.RoomNumber,
                        reservation.CustomerName,
                        reservation.CustomerPhone,
                        reservation.NumberOfDays,
                        reservation.PricePerDay,
                        reservation.SubTotal,
                        reservation.DiscountPercentage,
                        reservation.DiscountAmount,
                        reservation.TotalCost,
                        reservation.Status.ToString(),
                        reservation.ReservationDateUtc,
                        reservation.CheckInDate,
                        reservation.CheckOutDate,
                        reservation.CancelledAtUtc))
                .ToList();

        return new PagedResult<ReservationDto>(
            items,
            request.PageNumber,
            request.PageSize,
            totalCount);
    }
}