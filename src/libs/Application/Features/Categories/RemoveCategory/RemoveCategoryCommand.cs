namespace Application.Features.Categories.RemoveCategory;

public sealed record RemoveCategoryCommand
{
	public required Guid Id { get; init; }
}
