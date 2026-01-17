using Domain.Entities;

namespace Application.Features.Categories.RegisterCategory;

public sealed class RegisteredCategoryDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = default!;
	public CategoryPurpose Purpose { get; init; }
	public string? Description { get; init; }
}
