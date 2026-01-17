using Domain.Entities;

namespace Application.Features.Categories.RegisterCategory;

public sealed record RegisterCategoryCommand
{
	public string Name { get; init; } = default!;
	public string? Description { get; init; }
	public string Purpose { get; init; } = default!;
}
