using Domain.Entities;

namespace Application.Features.People.ListPeople;

public sealed class CategoryPurposeDto
{
	public int Value { get; init; }
	public string Text { get; init; } = default!;

	public static CategoryPurposeDto FromEnumValue(CategoryPurpose purpose) =>
		new CategoryPurposeDto
		{
			Value = (int)purpose,
			Text = purpose.ToString()
		};
}
