namespace Application.Features.Reporting.PerPersonTotalsReport;

public sealed record PerPersonTotalsReportDto
{
	public List<PerPersonTotalsReportLineItemDto> PerPersonReportLines { get; init; } = [];

	public decimal IncomeTotal { get => PerPersonReportLines.Sum(it => it.IncomeTotal); }
	public decimal ExpensesTotal { get => PerPersonReportLines.Sum(it => it.ExpensesTotal); }
	public decimal NetTotal { get => IncomeTotal - ExpensesTotal; }
}
