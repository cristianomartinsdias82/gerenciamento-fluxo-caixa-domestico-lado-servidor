namespace Application.Features.People.ListPeople;

public sealed class CategoryDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = default!;
	public CategoryPurposeDto Purpose { get; init; } = default!;
}
