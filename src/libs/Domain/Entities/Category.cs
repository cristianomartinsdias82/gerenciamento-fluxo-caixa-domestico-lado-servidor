using Common.Domain;

namespace Domain.Entities;

public sealed class Category : IEntity
{
	private Category() { }

	public Guid Id {  get; private set; }
	public string Name { get; private set; } = default!;
	public CategoryPurpose Purpose { get; private set; }
	public string? Description { get; set; } = default!;

	public static Category Create(
		string name,
		CategoryPurpose purpose,
		string? description)
		=> new()
		{
			Id = Guid.NewGuid(),
			Name = name,
			Purpose = purpose,
			Description = description
		};
}
