using Common.Domain;

namespace Domain.Entities;

public sealed class Category : IEntity
{
	private Category() { }

	public Guid Id {  get; private set; }
	public string Name { get; private set; } = default!;
	public string Description { get; set; } = default!;
	public CategoryPurpose Purpose { get; private set; }

	public static Category Create(
		string name,
		string description,
		CategoryPurpose purpose)
		=> new()
		{
			Id = Guid.NewGuid(),
			Name = name,
			Description = description,
			Purpose = purpose
		};
}
