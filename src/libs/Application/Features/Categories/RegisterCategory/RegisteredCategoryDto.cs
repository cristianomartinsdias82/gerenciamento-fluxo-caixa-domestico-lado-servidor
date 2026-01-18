namespace Application.Features.Categories.RegisterCategory;

public sealed class RegisteredCategoryDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = default!;
	public string Purpose { get; init; } = default!;
	public string? Description { get; init; }
}
