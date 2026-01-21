using Domain.Entities;
using FluentValidation;

namespace Application.Features.Transactions.RegisterTransaction;

public sealed class RegisterTransactionCommandValidator
	: AbstractValidator<RegisterTransactionCommand>
{
	private static string[] _transactionTypes = Enum.GetNames(typeof(TransactionType));

	public RegisterTransactionCommandValidator()
	{
		RuleFor(x => x.PersonId)
			.NotEmpty()
			.WithMessage("Person id must be valid.");

		RuleFor(x => x.CategoryId)
			.NotEmpty()
			.WithMessage("Category id must be valid.");

		RuleFor(x => x.Type)
			.NotEmpty()
			.WithMessage("Transaction type is required.")
			.Must(type => Enum.TryParse<TransactionType>(type, true, out _))
			.WithMessage($"Transaction type must one of the following: {string.Join(",", _transactionTypes)}.");

		RuleFor(x => x.Amount)
			.GreaterThan(0.00M)
			.WithMessage("Amount must be greater than 0.00.");

		RuleFor(x => x.Description)
			.NotEmpty()
			.WithMessage("Description is required.")
			.MinimumLength(3)
			.WithMessage("Description must be at least 3 characters long.")
			.MaximumLength(200)
			.WithMessage("Description must be no more than 200 characters long.");
	}
}
