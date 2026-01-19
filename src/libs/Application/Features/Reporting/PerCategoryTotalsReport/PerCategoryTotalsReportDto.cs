namespace Application.Features.Reporting.PerCategoryTotalsReport;

public sealed record PerCategoryTotalsReportDto
{
	public List<PerCategoryTotalsReportLineItemDto> PerCategoryReportLines { get; init; } = [];

	public decimal IncomeTotal { get => PerCategoryReportLines.Sum(it => it.IncomeTotal); }
	public decimal ExpensesTotal { get => PerCategoryReportLines.Sum(it => it.ExpensesTotal); }
	public decimal NetTotal { get => IncomeTotal - ExpensesTotal; }
}
