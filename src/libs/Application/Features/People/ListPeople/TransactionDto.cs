using Domain.Entities;

namespace Application.Features.People.ListPeople;

public sealed record TransactionDto
{
	public Guid Id { get; init; }
	public CategoryDto Category { get; init; } = default!;
	public string Type { get; init; } = default!;
	public string Description { get; init; } = default!;
	public decimal Amount { get; init; }
	public DateTimeOffset Date { get; init; }

	public static Func<Transaction, TransactionDto> Selector => t => new TransactionDto
	{
		Id = t.Id,
		Category = new CategoryDto
		{
			Id = t.Category.Id,
			Name = t.Category.Name,
			Purpose = CategoryPurposeDto.FromEnumValue(t.Category.Purpose)
		},
		Type = t.Type.ToString(),
		Description = t.Description,
		Amount = t.Amount,
		Date = t.Date
	};
}
