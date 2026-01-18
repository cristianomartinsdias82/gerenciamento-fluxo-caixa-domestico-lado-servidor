namespace Application.Features.People.ListPeople;

public sealed class PeopleListItemDto
{
	public Guid Id { get; init; }
	public string FullName { get; init; } = default!;
	public int Age { get; init; }
	public List<TransactionDto> Transactions { get; init; } = [];
}
