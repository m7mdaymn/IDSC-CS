using FluentValidation;
using HotelReservation.Application.Common.Exceptions;
using HotelReservation.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Api.ExceptionHandling;

public sealed class GlobalExceptionHandler
    : IExceptionHandler
{
    private readonly IProblemDetailsService
        _problemDetailsService;

    private readonly ILogger<GlobalExceptionHandler>
        _logger;

    public GlobalExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<GlobalExceptionHandler> logger)
    {
        _problemDetailsService =
            problemDetailsService;

        _logger =
            logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, title) =
            exception switch
            {
                ValidationException =>
                    (
                        StatusCodes.Status400BadRequest,
                        "Validation failed"
                    ),

                DomainException =>
                    (
                        StatusCodes.Status400BadRequest,
                        "Business rule violation"
                    ),

                NotFoundException =>
                    (
                        StatusCodes.Status404NotFound,
                        "Resource not found"
                    ),

                ConflictException =>
                    (
                        StatusCodes.Status409Conflict,
                        "Conflict"
                    ),

                _ =>
                    (
                        StatusCodes.Status500InternalServerError,
                        "Unexpected error"
                    )
            };


        if (statusCode ==
            StatusCodes.Status500InternalServerError)
        {
            _logger.LogError(
                exception,
                "Unhandled exception. TraceId: {TraceId}",
                httpContext.TraceIdentifier);
        }


        var problemDetails =
            new ProblemDetails
            {
                Status =
                    statusCode,

                Title =
                    title,

                Detail =
                    exception.Message,

                Instance =
                    httpContext.Request.Path
            };


        problemDetails.Extensions["traceId"] =
            httpContext.TraceIdentifier;


        if (exception is
            ValidationException validationException)
        {
            problemDetails.Extensions["errors"] =
                validationException.Errors
                    .GroupBy(
                        error =>
                            error.PropertyName)
                    .ToDictionary(
                        group =>
                            group.Key,

                        group =>
                            group
                                .Select(
                                    error =>
                                        error.ErrorMessage)
                                .Distinct()
                                .ToArray());
        }


        httpContext.Response.StatusCode =
            statusCode;


        return await
            _problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext
                {
                    HttpContext =
                        httpContext,

                    ProblemDetails =
                        problemDetails
                });
    }
}