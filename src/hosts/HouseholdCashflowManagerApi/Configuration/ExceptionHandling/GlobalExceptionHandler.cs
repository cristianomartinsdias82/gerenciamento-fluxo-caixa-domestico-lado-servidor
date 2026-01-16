using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdCashFlowManagementApi.Configuration.ErrorHandling;

internal sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IHostEnvironment hostEnvironment,
    IProblemDetailsService problemDetailsService) : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(
    HttpContext httpContext,
    Exception exception,
    CancellationToken cancellationToken)
    {
      logger.LogError(exception, "An unhandled exception occurred.");

      httpContext.Response.StatusCode = exception switch
      {
        ApplicationException => StatusCodes.Status400BadRequest,
		TransactionTypeCategoryPurposeMismatchException => StatusCodes.Status400BadRequest,
        _ => StatusCodes.Status500InternalServerError
      };

      return await problemDetailsService.TryWriteAsync(
        new ProblemDetailsContext
        {
          HttpContext = httpContext,
          Exception = exception,
          ProblemDetails =  new ProblemDetails
          {
            Type = exception.GetType().FullName,
            Title = "An error occurred.",
            Detail = exception.Message,
            Extensions = hostEnvironment.IsDevelopment()
                            ? new Dictionary<string, object?>
                              {
                                ["stackTrace"] = exception.StackTrace
                              }
                            : default!
          }
        }
      );
    }
}