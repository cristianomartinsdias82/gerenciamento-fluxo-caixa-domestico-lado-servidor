namespace Application.Features.Transactions.ListTransactions;

public sealed record CategoryDto
{
	public string Name { get; init; } = default!;
	public string Purpose { get; init; } = default!;
}
