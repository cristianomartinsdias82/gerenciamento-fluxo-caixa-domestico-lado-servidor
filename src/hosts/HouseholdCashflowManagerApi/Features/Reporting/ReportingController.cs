using Application.Features.Reporting.PerCategoryTotalsReport;
using Application.Features.Reporting.PerPersonTotalsReport;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace HouseholdCashFlowManagementApi.Features.Reporting;

[ApiController]
[Route("api/[controller]")]
public sealed class ReportingController(IMessageBus messageBus) : ControllerBase
{
	[HttpGet("per-person-totals")]
	public async ValueTask<IActionResult> PerPersonTotalsReport(
		CancellationToken cancellationToken)
	{
		var pagedResult = await messageBus.InvokeAsync<PerPersonTotalsReportDto>(
			new PerPersonTotalsReportQuery(),
			cancellationToken);

		return Ok(pagedResult);
	}

	[HttpGet("per-category-totals")]
	public async ValueTask<IActionResult> PerCategoryTotalsReport(
		CancellationToken cancellationToken)
	{
		var pagedResult = await messageBus.InvokeAsync<PerCategoryTotalsReportDto>(
			new PerCategoryTotalsReportQuery(),
			cancellationToken);

		return Ok(pagedResult);
	}
}
