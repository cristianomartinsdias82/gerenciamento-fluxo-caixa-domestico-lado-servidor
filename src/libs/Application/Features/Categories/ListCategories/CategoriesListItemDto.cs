using Application.Features.Categories.ListPeople;

namespace Application.Features.Categories.ListCategories;

public sealed class CategoriesListItemDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = default!;
	public CategoryPurposeDto Purpose { get; init; } = default!;
}
