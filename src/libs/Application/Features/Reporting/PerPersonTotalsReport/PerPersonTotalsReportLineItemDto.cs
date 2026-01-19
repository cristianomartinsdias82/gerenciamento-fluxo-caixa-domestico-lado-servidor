namespace Application.Features.Reporting.PerPersonTotalsReport;

public sealed record PerPersonTotalsReportLineItemDto
{
	public Guid PersonId { get; init; } = default!;
	public string PersonName { get; init; } = default!;
	public decimal IncomeTotal { get; init; }
	public decimal ExpensesTotal { get; init; }
	public decimal NetTotal { get => IncomeTotal - ExpensesTotal; }
}
