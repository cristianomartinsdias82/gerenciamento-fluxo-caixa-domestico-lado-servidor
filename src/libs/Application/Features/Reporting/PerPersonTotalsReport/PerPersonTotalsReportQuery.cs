using HouseholdCashFlowManagementApi.Common.Searching;

namespace Application.Features.Reporting.PerPersonTotalsReport;

public sealed record PerPersonTotalsReportQuery
{
	public required QueryParams QueryParams { get; init; }
}
