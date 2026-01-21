namespace Application.Features.Transactions.RegisterTransaction;

public sealed record RegisteredTransactionDto
{
	public Guid Id { get; init; }
	public Guid PersonId { get; init; } = default!;
	public Guid CategoryId { get; init; } = default!;
	public string Type { get; init; } = default!;
	public string Description { get; init; } = default!;
	public decimal Amount { get; init; }
}