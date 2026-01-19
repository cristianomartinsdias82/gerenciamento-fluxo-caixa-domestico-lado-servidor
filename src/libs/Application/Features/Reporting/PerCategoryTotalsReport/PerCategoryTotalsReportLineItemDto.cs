namespace Application.Features.Reporting.PerCategoryTotalsReport;

public sealed record PerCategoryTotalsReportLineItemDto
{
	public Guid CategoryId { get; init; } = default!;
	public string CategoryName { get; init; } = default!;
	public decimal IncomeTotal { get; init; }
	public decimal ExpensesTotal { get; init; }
	public decimal NetTotal { get => IncomeTotal - ExpensesTotal; }
}
