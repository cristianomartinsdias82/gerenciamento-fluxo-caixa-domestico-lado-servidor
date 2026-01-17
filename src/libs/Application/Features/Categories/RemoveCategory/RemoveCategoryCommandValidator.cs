using FluentValidation;

namespace Application.Features.Categories.RemoveCategory;

public sealed class RemoveCategoryCommandValidator
	: AbstractValidator<RemoveCategoryCommand>
{
	public RemoveCategoryCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("The category id must be valid.");
	}
}
