using FluentValidation;

namespace Application.Features.People.RemovePerson;

public sealed class RemovePersonCommandValidator
	: AbstractValidator<RemovePersonCommand>
{
	public RemovePersonCommandValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("The person id must be valid.");
	}
}
