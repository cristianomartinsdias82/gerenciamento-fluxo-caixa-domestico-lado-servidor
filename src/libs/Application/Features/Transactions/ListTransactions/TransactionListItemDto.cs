using Domain.Entities;

namespace Application.Features.Transactions.ListTransactions;

public sealed record TransactionsListItemDto
{
	public Guid Id { get; init; }
	public PersonDto Person { get; init; } = default!;
	public CategoryDto Category { get; init; } = default!;
	public string Type { get; init; } = default!;
	public string Description { get; init; } = default!;
	public decimal Amount { get; init; }
	public DateTimeOffset Date { get; init; }

	public static Func<Transaction, TransactionsListItemDto> Selector => t => new()
	{
		Id = t.Id,
		Category = new()
		{
			Name = t.Category.Name,
			Purpose = t.Category.Purpose.ToString()
		},
		Person = new()
		{
			Id = t.Person.Id,
			FullName = t.Person.FullName,
		},
		Type = t.Type.ToString(),
		Description = t.Description,
		Amount = t.Amount,
		Date = t.Date
	};
}
