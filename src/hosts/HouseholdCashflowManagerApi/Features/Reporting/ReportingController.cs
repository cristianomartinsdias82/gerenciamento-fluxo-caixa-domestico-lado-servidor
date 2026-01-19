using Application.Features.Reporting.PerPersonTotalsReport;
using HouseholdCashFlowManagementApi.Common.Searching;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace HouseholdCashFlowManagementApi.Features.Reporting;

[ApiController]
[Route("api/[controller]")]
public sealed class ReportingController(IMessageBus messageBus) : ControllerBase
{
	[HttpGet]
	public async ValueTask<IActionResult> PerPersonTotalsReport(
		[FromQuery] QueryParams queryParams,
		CancellationToken cancellationToken)
	{
		var pagedResult = await messageBus.InvokeAsync<PerPersonTotalsReportDto>(
			new PerPersonTotalsReportQuery { QueryParams = queryParams },
			cancellationToken);

		return Ok(pagedResult);
	}
}
