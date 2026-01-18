namespace Application.Features.Transactions.ListTransactions;

public sealed record PersonDto
{
	public Guid Id { get; init; }
	public string FullName { get; init; } = default!;
}
