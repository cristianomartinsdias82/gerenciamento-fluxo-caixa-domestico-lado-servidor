using Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdCashFlowManagementApi.Configuration.ErrorHandling;

internal sealed class BusinessRuleExceptionHandler(
	IProblemDetailsService problemDetailsService) : IExceptionHandler
{
	public async ValueTask<bool> TryHandleAsync(
	  HttpContext httpContext,
	  Exception exception,
	  CancellationToken cancellationToken)
	{
		if (exception is not BusinessRuleException businessRuleException)
			return false;

		httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

		var context = new ProblemDetailsContext
		{
			HttpContext = httpContext,
			Exception = exception,
			ProblemDetails = new ProblemDetails
			{
				Title = "A business rule violation error occurred when processing your request.",
				Detail = businessRuleException.Message,
				Status = httpContext.Response.StatusCode
			}
		};

		return await problemDetailsService.TryWriteAsync(context);
	}
}