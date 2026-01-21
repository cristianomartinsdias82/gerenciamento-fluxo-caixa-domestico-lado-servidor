using Domain.Entities;
using FluentValidation;

namespace Application.Features.Categories.RegisterCategory;

public sealed class RegisterCategoryCommandValidator
	: AbstractValidator<RegisterCategoryCommand>
{
	private static string[] _purposes = Enum.GetNames(typeof(CategoryPurpose));

	public RegisterCategoryCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Name is required.")
			.MinimumLength(3)
			.WithMessage("Name must be at least 3 characters long.")
			.MaximumLength(50)
			.WithMessage("Name must be no more than 50 characters long.");

		RuleFor(x => x.Purpose)
			.NotEmpty()
			.WithMessage("Purpose is required.")
			.Must(purpose => Enum.TryParse<CategoryPurpose>(purpose, true, out _))
			.WithMessage($"Purpose must one of the following: {string.Join(",",_purposes)}.");

		When(x => !string.IsNullOrWhiteSpace(x.Description), () => {
			RuleFor(x => x.Description)
			.MaximumLength(500)
			.WithMessage("Description must be no more than 500 characters long.");
		});
	}
}
