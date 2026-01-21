using FluentValidation;

namespace Application.Features.People.RegisterPerson;

public sealed class RegisterPersonCommandValidator
	: AbstractValidator<RegisterPersonCommand>
{
	public RegisterPersonCommandValidator()
	{
		RuleFor(x => x.FullName)
			.NotEmpty()
			.WithMessage("Full name is required.")
			.MinimumLength(10)
			.WithMessage("Full name must be at least 10 characters long.")
			.MaximumLength(200)
			.WithMessage("Full name must be no more than 200 characters long.");

		RuleFor(x => x.Age)
			.GreaterThanOrEqualTo(5)
			.WithMessage("Age must be at least 5.")
			.LessThan(120)
			.WithMessage("Age must be no more than 120.");
	}
}
