namespace Application.Features.Transactions.RegisterTransaction;

public sealed record RegisterTransactionCommand
{
	public Guid PersonId { get; set; }
	public Guid CategoryId { get; init; }
	public decimal Amount { get; init; }
	public string Type { get; init; } = default!;
	public string Description { get; init; } = default!;
}
